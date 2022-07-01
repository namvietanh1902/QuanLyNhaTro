using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhaTro.Models;
using QuanLyNhaTro.DTO;
using System.Windows.Forms;
using System.Data.Entity;

namespace QuanLyNhaTro.BLL
{
    public class BLL_Receipt: BLL_Main
    {
        private static BLL_Receipt _instance;

        public static BLL_Receipt Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BLL_Receipt();
                }
                return _instance;
            }
            private set { }
        }
        public List<MonthlyReceipt> getAllMonthlyReceipt()
        {
            return db.MonthlyReceipts.Select(c => c).ToList();
        }
        public List<ServiceReceipt> getAllServiceReceipt()
        {
            return db.ServiceReceipts.Select(c => c).ToList();
        }
        public List<Receipt> GetReceiptByCusID(int id)
        {
            return db.Receipts.Where(p => p.Contract.Customer.CustomerId.Equals(id)).ToList(); 
        }
        public MonthlyReceipt GetMonthlyReceiptByID(int ID)
        {
            return db.MonthlyReceipts.Find(ID);
        }
        public List<Receipt> GetAllReceipt()
        {
            return db.Receipts.Select(c => c).ToList();
        }

        public bool checkMonth(MonthlyReceipt i)
        {   
            var contract = db.Contracts.Find(i.ContractID);
            if (i.Month.Month < ((DateTime)contract.CreatedAt).Month)
            {
                MessageBox.Show("Hợp đồng chưa tồn tại vào tháng này");
                return false;
            }
            foreach (MonthlyReceipt item in getAllMonthlyReceipt())
            {
                if (i.ContractID == item.ContractID && i.Month.Month == item.Month.Month && item.Month.Year == i.Month.Year)
                {
                    MessageBox.Show("Tháng này đã được tính tiền");
                    return false;
                }
            }
            return true;
        }
        public int GetPreviousMonthElecAfter(DateTime a,int id)
        {
            return db.MonthlyReceipts.Where(c => c.ContractID == id).Where(p => p.Month.Month == a.Month - 1).Select(c =>(int?) c.ElecAfter).FirstOrDefault() ?? 0;
        }
        public int GetPreviousMonthWaterAfter(DateTime a, int id)
        {
            return db.MonthlyReceipts.Where(c => c.ContractID == id).Where(p => p.Month.Month == a.Month - 1).Select(c => (int?)c.WaterAfter).FirstOrDefault() ?? 0;
        }
        public bool AddMonthlyReceipt(MonthlyReceipt i)
        {
            if (!checkMonth(i))
            {
                return false;
            }
            else
            {
                try
                {
                    new Common.ModelDataValidation().Validate(i);
                    db.MonthlyReceipts.Add(i);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo lỗi");
                }
            }
            return true;
        }
        public List<ServiceReceipt_View> GetReceiptDetail(int mahoadon)
        {
            List<ServiceReceipt_View> list = new List<ServiceReceipt_View>();
            Receipt receipt = GetReceiptByID(mahoadon);
            foreach(ServiceReceiptDetail srd in GetAllServiceReceiptDetails())
            {
                if(srd.ServiceReceiptId == receipt.ReceiptID)
                {
                    ServiceReceipt_View data = new ServiceReceipt_View();
                    data.ServiceID = srd.ServiceId;
                    data.Number = srd.Number;
                    foreach(Service sr in BLL_Service.Instance.GetAllService())
                    {
                        if(sr.ServiceId == data.ServiceID)
                        {
                            data.Name = sr.Name;
                            data.Price = sr.Price*data.Number;
                            list.Add(data);
                        }
                    }
                }
            }
            return list;
        }
        public int AddServiceReceipt(List<ServiceReceipt_View> data, int CustomerID)
        {
            int total = 0;
            if (data != null)
            {
                foreach (ServiceReceipt_View item in data)
                {
                    total += item.Price * item.Number;
                }
                ServiceReceipt receipt = new ServiceReceipt
                {
                    ContractID = BLL_Contract.Instance.GetContractByCustomerID(CustomerID).ContractId,
                    Total = total,
                    PaidDate = DateTime.Now,
                };
                db.ServiceReceipts.Add(receipt);
                db.SaveChanges();
                List<ServiceReceiptDetail> details = new List<ServiceReceiptDetail>();
                foreach (ServiceReceipt_View item in data)
                {
                    details.Add(new ServiceReceiptDetail
                    {
                        ServiceReceiptId = receipt.ReceiptID,
                        Number = item.Number,
                        ServiceId = item.ServiceID,
                    });
                }
                db.ServiceReceiptDetails.AddRange(details);
                db.SaveChanges();
            }
            return total;
        }

        public List<ServiceReceiptDetail> GetAllServiceReceiptDetails()
        {
            return db.ServiceReceiptDetails.Select(c => c).ToList();
        }  
        public int GetTotalIncome()
        {
            return db.Receipts.Where(p => p.isPaid).Select(p => p).Sum(p=> (int?)p.Total) ??  0;
        }
        public int GetIncome(DateTime from, DateTime To)
        {
            return db.Receipts.Where(p => p.isPaid).Where(p => DbFunctions.TruncateTime(p.PaidDate) >= DbFunctions.TruncateTime(from) && DbFunctions.TruncateTime(p.PaidDate) <= DbFunctions.TruncateTime(To)).Select(p => p).Sum(p => (int?)p.Total) ?? 0;
        }
        public void PaidReceipt(int id)
        {
            db.Receipts.Find(id).isPaid = true;
            db.SaveChanges();
        }
        public List<Receipt_View> Sort(List<int> current,string SortType)
        {
            var list = new List<Receipt_View>();
            foreach(var item in GetAllReceiptView())
            {
                foreach (var i in current)
                {
                    if (item.ReceiptID == i)
                    {
                        list.Add(item);
                        break;
                    }
                }
            }
            switch (SortType)
            {
                case "Giá tiền":
                    {
                        return list.OrderBy(p => p.Total).ToList();
                    }
                default:
                    {
                        return list.OrderBy(p=>p.CreatedAt).ToList();
                    }
            }
        }
        public int TotalInMonth(DateTime a)
        {
            int Total = 0;
            foreach (Receipt spv in GetAllReceipt())
                if (((DateTime)spv.PaidDate).Month == a.Month && ((DateTime)spv.PaidDate).Year == a.Year && spv.isPaid == true)
                    Total += spv.Total;
            return Total;
        }
        public int TotalInYear(DateTime a)
        {
            int Total = 0;
            foreach (Receipt spv in GetAllReceipt())
                if (((DateTime)spv.PaidDate).Year == a.Year && spv.isPaid == true)
                    Total += spv.Total;

            return Total;
        }
        public List<Receipt_View> GetAllReceiptView()
        {         
                return GetReceiptView(GetAllReceipt(),DateTime.MinValue,DateTime.MinValue);    
        }
        public Receipt GetReceiptByID(int id)
        {
            return db.Receipts.Find(id);
        }
      
        public List<Receipt_View> GetReceiptView(List<Receipt> data,DateTime a,DateTime b)
        {
            var list = new List<Receipt_View>();
            if (a ==DateTime.MinValue || b == DateTime.MinValue)
            {
            foreach (Receipt i in data)
            { 
                list.Add(new Receipt_View
                {
                    ReceiptID = i.ReceiptID,
                    CustomerName = i.Contract.Customer.Name,
                    Total = i.Total,
                    CreatedAt = ((DateTime)i.PaidDate).ToString("dd-MM-yyyy"),
                    isPaid = i.isPaid,
                    ReceiptType = i is MonthlyReceipt ? "Hóa đơn tháng" : "Hóa đơn dịch vụ"
                });

            }
            }
            else
            {   
                foreach (Receipt i in data)
                {   
                    if(((DateTime)i.PaidDate).Date >= a.Date && ((DateTime)i.PaidDate).Date <= b.Date)
                    {

                    list.Add(new Receipt_View
                    {
                        ReceiptID = i.ReceiptID,
                        CustomerName = i.Contract.Customer.Name,
                        Total = i.Total,
                        CreatedAt = ((DateTime)i.PaidDate).ToString("dd-MM-yyyy"),
                        isPaid = i.isPaid,
                        ReceiptType = i is MonthlyReceipt ? "Hóa đơn tháng" : "Hóa đơn dịch vụ"
                    });
                    }

                }

            }
            return list;
        }

        public List<Receipt_View> Search(int id, string Status, string Type,DateTime from,DateTime to)
        {
            var list = new List<Receipt_View>();
            var data = new List<Receipt_View>();
            if (id == 0)
            {
                list = GetReceiptView(GetAllReceipt(),from,to);

            }
            else
            {
                list = GetReceiptView(GetReceiptByCusID(id),from,to);
            }
            if (Status == "All" && Type == "All")
            {
                data = list;
            }
            else if (Status != "All"&&Type=="All")
            {
            bool isPaid = Status == "Đã thanh toán" ? true : false;

                foreach (var i in list)
                {
                    if(i.isPaid == isPaid)
                    {
                        data.Add(i);
                    }
                }
            }
            else if(Status == "All" && Type != "All")
            {
                foreach(var i in list)
                {
                    if(i.ReceiptType == Type)
                    {
                        data.Add(i);
                    }
                }
            }
            else
            {
                bool isPaid = Status == "Đã thanh toán" ? true : false;

                foreach (var i in list)
                {
                    if (i.ReceiptType == Type&&i.isPaid == isPaid)
                    {
                        data.Add(i);
                    }
                }
            }
            return data;
        }
        public List<Receipt_View> GetReceipt_ViewsById(int id)
        {
            var list = new List<Receipt_View>();
            foreach (Receipt i in GetAllReceipt())
            {
                if (i.ContractID == id && i.isPaid == false)
                    list.Add(new Receipt_View
                    {
                        ReceiptID = i.ReceiptID,
                        CustomerName = i.Contract.Customer.Name,
                        Total = i.Total,
                        isPaid = i.isPaid,
                        CreatedAt = ((DateTime)i.PaidDate).ToString("dd-MM-yyyy"),
                        ReceiptType = i is MonthlyReceipt ? "Hóa đơn tháng" : "Hóa đơn dịch vụ"
                    });

            }
            return list;
        }
    }
}
