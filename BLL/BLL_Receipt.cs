using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhaTro.Models;
using QuanLyNhaTro.DTO;
using System.Windows.Forms;

namespace QuanLyNhaTro.BLL
{
    public class BLL_Receipt
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
            using (QuanLy db = new QuanLy())
            {

            return db.MonthlyReceipts.Select(c => c).ToList();
            }
        }
        public List<ServiceReceipt> getAllServiceReceipt()
        {
            using (QuanLy db = new QuanLy())
            {

            return db.ServiceReceipts.Select(c => c).ToList();
            }
        }

        public ServiceReceipt GetServiceReceiptByID(int ID)
        {
            using (QuanLy db = new QuanLy())
            {
            return db.ServiceReceipts.Find(ID);

            }
        }
        public List<Receipt> GetReceiptByCusID(int id)
        {
            using (QuanLy db = new QuanLy())
            {
            return db.Receipts.Where(p => p.Contract.Customer.CustomerId.Equals(id)).ToList(); 

            }
        }
        public MonthlyReceipt GetMonthlyReceiptByID(int ID)
        {
            using (QuanLy db = new QuanLy())
            {

            return db.MonthlyReceipts.Find(ID);
            }
        }

        public List<Receipt> GetAllReceipt()
        {
            using (QuanLy db = new QuanLy())
            {

            return db.Receipts.Select(c => c).ToList();
            }
        }


        public bool checkMonth(MonthlyReceipt i)
        {   
            if (i.Month < i.Contract.CreatedAt)
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
        public void AddMonthlyReceipt(MonthlyReceipt i)
        {
            using (QuanLy db = new QuanLy())
            {

            if (!checkMonth(i))
            {
               
                return;
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
            }
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



        public void AddServiceReceipt(List<ServiceReceipt_View> data, int CustomerID)
        {
            using (QuanLy db = new QuanLy())
            {

            if (data != null)
            {
                int total = 0;
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
            }
        }

        public List<ServiceReceiptDetail> GetAllServiceReceiptDetails()
        {
            using (QuanLy db = new QuanLy())
            {

            return db.ServiceReceiptDetails.Select(c => c).ToList();
            }
        }
        
        public List<ReceiptPaid_View> GetAllReceiptPaid_Views()
        {
            List<ReceiptPaid_View> spv = new List<ReceiptPaid_View>();
            foreach (MonthlyReceipt mr in getAllMonthlyReceipt())
                if (!BLL_Customer.Instance.IsDelete(mr.ContractID))
                {
                    ReceiptPaid_View a = new ReceiptPaid_View();
                    a.ReceiptID = mr.ReceiptID;
                    a.Total = mr.Total;
                    a.Month = mr.Month;
                    a.IsPaid = mr.isPaid;
                    a.WaterBefore = mr.WaterBefore;
                    a.WaterAfter = mr.WaterAfter;
                    a.WaterBill = mr.WaterBill;
                    a.RoomBill = mr.RoomBill;
                    a.ElecBefore = mr.ElecBefore;
                    a.ElecAfter = mr.ElecAfter;
                    a.ElecBill = mr.ElecBill;
                    foreach (Customer c in BLL_Customer.Instance.GetAllCustomer())
                        if (c.CustomerId == mr.ContractID)
                            a.CustomerName = c.Name;
                    spv.Add(a);
                }
            return spv;
        }
        public List<ReceiptPaid_View> FindService(string name, string tinhtrang)
        {
            List<ReceiptPaid_View> find = new List<ReceiptPaid_View>();
            List<ReceiptPaid_View> find2 = new List<ReceiptPaid_View>();
            foreach (ReceiptPaid_View spv in GetAllReceiptPaid_Views())
                if (spv.CustomerName.Contains(name))
                    find.Add(spv);
            if (tinhtrang == "Tất cả")
                return find;
            foreach (ReceiptPaid_View spv in find)
                find2.Add(spv);

            foreach (ReceiptPaid_View spv in find2)
                if (spv.IsPaid.ToString() != tinhtrang)
                    find.Remove(spv);
            return find;
        }
        public int GetTotalIncome()
        {
            using (QuanLy db = new QuanLy())
            {

            return db.Receipts.Where(p => p.isPaid && !p.Contract.Customer.isDelete).Select(p => p).Sum(p=> (int?)p.Total) ??  0;
            }
        }
        public void PaidReceipt(int id)
        {
            using (QuanLy db = new QuanLy())
            {

            db.Receipts.Find(id).isPaid = true;
            db.SaveChanges();
            }
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
                if (((DateTime)spv.PaidDate).Month == a.Month && ((DateTime)spv.PaidDate).Year == a.Year && spv.isPaid == true && spv.Contract.Customer.isDelete == false)
                    Total += spv.Total;

            return Total;
        }
        public int TotalInYear(DateTime a)
        {
            int Total = 0;
            foreach (Receipt spv in GetAllReceipt())
                if (((DateTime)spv.PaidDate).Year == a.Year && spv.isPaid == true && spv.Contract.Customer.isDelete == false)
                    Total += spv.Total;

            return Total;

        }
        public List<Receipt_View> GetAllReceiptView()
        {         
                return GetReceiptView(GetAllReceipt());    
        }

        public Receipt GetReceiptByID(int id)
        {
            using (QuanLy db = new QuanLy())
            {

            return db.Receipts.Find(id);
            }
        }
        public List<Receipt_View> GetReceiptView(List<Receipt> data)
        {
            var list = new List<Receipt_View>();
            foreach (Receipt i in data)
            {
                if(i.Contract.Customer.isDelete==false)
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
            return list;
        }

        public List<Receipt_View> Search(int id, string Status, string Type)
        {
            var list = new List<Receipt_View>();
            var data = new List<Receipt_View>();
            if (id == 0)
            {
                list = GetReceiptView(GetAllReceipt());

            }
            else
            {
                list = GetReceiptView(GetReceiptByCusID(id));
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
        public MonthlyReceipt GetMonthlyReceiptbyId(int mahoadon)
        {
            foreach(MonthlyReceipt mr in getAllMonthlyReceipt())
            {
                if(mr.ReceiptID == mahoadon)
                {
                    return mr;
                    
                }
            }
            return null;
        }

        public List<Receipt_View> GetReceipt_ViewsById(int id)
        {
            var list = new List<Receipt_View>();
            foreach (Receipt i in GetAllReceipt())
            {
                if (i.Contract.Customer.isDelete == false && i.ContractID == id && i.isPaid == false)
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
