using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhaTro.Models;
using QuanLyNhaTro.DTO;

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
        public List<MonthlyReceipt> getAllMonthlyReceipt()
        {
            return QuanLy.Instance.MonthlyReceipts.Select(c=>c).ToList();
        }
        public List<ServiceReceipt> getAllServiceReceipt()
        {
            return QuanLy.Instance.ServiceReceipts.Select(c => c).ToList();
        }
        public List<Receipt> GetAllReceipts()
        {
            List<Receipt> data = new List<Receipt>();
            foreach (MonthlyReceipt i in getAllMonthlyReceipt())
            {
                data.Add(new Receipt
                {
                    ContractID = i.ContractID,
                    ReceiptID = i.MonthlyReceiptId,
                    ReceiptType = "Hóa đơn tháng",
                    Total = i.TotalBill,
                    isPaid = i.isPaid
                });
            }
            foreach (ServiceReceipt i in getAllServiceReceipt())
            {
                data.Add(new Receipt
                {
                    ContractID = i.ContractID,
                    ReceiptID = i.ServiceReceiptId,
                    ReceiptType = "Hóa đơn dịch vụ",
                    Total = i.Total,
                    isPaid = i.isPaid
                });
            }
            return data;

        }
        public ServiceReceipt GetServiceReceiptByID(int ID)
        {
            return QuanLy.Instance.ServiceReceipts.Find(ID);
        }
        public MonthlyReceipt GetMonthlyReceiptByID(int ID)
        {
            return QuanLy.Instance.MonthlyReceipts.Find(ID);
        }
        public List<Receipt> GetAllUnpaidReceipt()
        {
            List<Receipt> data = new List<Receipt>();
            foreach (Receipt i in GetAllReceipts())
            {
                if (i.isPaid == false) data.Add(i);
            }
            return data;
        }

        public void PayReceipt(Receipt i)
        {
            switch (i.ReceiptType)
            {
                case "Hóa đơn tháng":
                    {
                        GetMonthlyReceiptByID(i.ReceiptID).isPaid = true;
                        QuanLy.Instance.SaveChanges();
                        break;
                    }
                default:
                    {
                        GetServiceReceiptByID(i.ReceiptID).isPaid= true;
                        QuanLy.Instance.SaveChanges();
                        break;
                    }
            }

        }
    }
}
