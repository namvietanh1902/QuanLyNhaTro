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
        public int GetNextServiceReceiptID()
        {
            if (QuanLy.Instance.ServiceReceipts.Count() == 0) return 1;
            return QuanLy.Instance.ServiceReceipts.Max(c => c.ReceiptID) + 1;
        }

        public List<MonthlyReceipt> getAllMonthlyReceipt()
        {
            return QuanLy.Instance.MonthlyReceipts.Select(c => c).ToList();
        }
        public List<ServiceReceipt> getAllServiceReceipt()
        {
            return QuanLy.Instance.ServiceReceipts.Select(c => c).ToList();
        }

        public ServiceReceipt GetServiceReceiptByID(int ID)
        {
            return QuanLy.Instance.ServiceReceipts.Find(ID);
        }
        public MonthlyReceipt GetMonthlyReceiptByID(int ID)
        {
            return QuanLy.Instance.MonthlyReceipts.Find(ID);
        }

        public List<Receipt> getAllReceipt()
        {
            return QuanLy.Instance.Receipts.Select(c => c).ToList();
        }


        public bool checkMonth(MonthlyReceipt i)
        {
            foreach (MonthlyReceipt item in getAllMonthlyReceipt())
            {
                if (i.ContractID == item.ContractID && i.Month.Month == item.Month.Month && item.Month.Year == i.Month.Year)
                {
                    return false;
                }
            }
            return true;
        }
        public void AddMonthlyReceipt(MonthlyReceipt i)
        {
            if (!checkMonth(i))
            {
                MessageBox.Show("Tháng này đã được tính tiền");
                return;
            }
            else
            {
                QuanLy.Instance.MonthlyReceipts.Add(i);
                QuanLy.Instance.SaveChanges();
            }
        }



        public void AddServiceReceipt(List<ServiceReceipt_View> data, int CustomerID)
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
                QuanLy.Instance.ServiceReceipts.Add(receipt);
                QuanLy.Instance.SaveChanges();
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
                QuanLy.Instance.ServiceReceiptDetails.AddRange(details);
                QuanLy.Instance.SaveChanges();
            }
        }

        public List<ServiceReceiptDetail> GetAllServiceReceiptDetails()
        {
            return QuanLy.Instance.ServiceReceiptDetails.Select(c => c).ToList();
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

        public void PaidReceipt(int id, bool ispaid)
        {
            QuanLy.Instance.MonthlyReceipts.Find(id).isPaid = ispaid;
        }
        public List<ReceiptPaid_View> Sort()
        {
            return GetAllReceiptPaid_Views().OrderBy(s => s.Total).ToList();
        }
        public int TotalService(DateTime a)
        {
            int Total = 0;
            foreach (ReceiptPaid_View spv in GetAllReceiptPaid_Views())
                if (spv.Month.Month == a.Month && spv.Month.Year == a.Year && spv.IsPaid == true)
                    Total += spv.Total;

            return Total;
        }
        public int TotalServiceFull()
        {
            int Total = 0;
            foreach (ReceiptPaid_View spv in GetAllReceiptPaid_Views())
                    Total += spv.Total;

            return Total;
        }
    }
}
