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

        public static BLL_Receipt Instance {
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
            return QuanLy.Instance.MonthlyReceipts.Select(c=>c).ToList();
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
       
       
        public bool checkMonth(MonthlyReceipt i)
        {
            foreach(MonthlyReceipt item in getAllMonthlyReceipt())
            {
                if (i.ContractID ==item.ContractID &&i.Month.Month ==item.Month.Month &&item.Month.Year == i.Month.Year)
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
        

        
        public void AddServiceReceipt(List<ServiceReceipt_View> data,int CustomerID)
        {
            if (data!= null)
            {
                int total = 0;
                foreach(ServiceReceipt_View item in data)
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
    }
}
