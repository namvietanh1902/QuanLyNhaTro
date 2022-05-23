using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhaTro.Models;

namespace QuanLyNhaTro.DAO
{
    public class DAL_Receipt
    {
        private static DAL_Receipt _instance;

        public static DAL_Receipt Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DAL_Receipt();
                }
                return _instance;
            }
            private set { }
        }

        //public List<ReceiptModel> GetAllReceipt()
        //{
        //    List<ReceiptModel> res = new List<ReceiptModel>();
        //    string query = "Select * from HopDongThuePhong";
        //    foreach (DataRow i in DBHelper.Instance.GetRecords(query, null).Rows)
        //    {
        //        res.Add(GetReceiptFromDataRow(i));
        //    }
        //    return res;
        //}

        //private ReceiptModel GetReceiptFromDataRow(DataRow i)
        //{
        //    return new ReceiptModel
        //    {
        //        MaThue = Convert.ToInt32(i["MaHopDong"].ToString()),
        //        MaPhong = Convert.ToInt32(i["MaPhong"].ToString()),
        //        MaKhach = Convert.ToInt32(i["MaKhach"].ToString()),
        //        NgayThue = Convert.ToDateTime(i["NgayThue".ToString()]),
        //        TenKhach = i["TenKhach"].ToString(),

        //    };
        //}

        //public void AddReceipt(ReceiptModel receipt)
        //{
        //    SqlParameter[] para = new SqlParameter[]
        //    {
        //        new SqlParameter{ParameterName = "@MaPhong",Value = receipt.MaPhong},
        //        new SqlParameter{ParameterName = "@MaKhach",Value = receipt.MaKhach},
        //        new SqlParameter{ParameterName = "@NgayThue",Value = receipt.NgayThue },
        //        new SqlParameter{ParameterName = "@TenKhach",Value = receipt.TenKhach},

        //    };
        //    string query = "insert into HopDongThuePhong values (@MaPhong,@MaKhach,@NgayThue,@TenKhach)";
        //    DBHelper.Instance.ExecuteDB(query, para);
        //}

        //public void UpdateReceipt(ReceiptModel receipt)
        //{
        //    SqlParameter[] para = new SqlParameter[]
        //   {
        //        new SqlParameter{ParameterName = "@MaThue",Value = receipt.MaThue},
        //        new SqlParameter{ParameterName = "@MaPhong",Value = receipt.MaPhong},
        //        new SqlParameter{ParameterName = "@MaKhach",Value = receipt.MaKhach},
        //        new SqlParameter{ParameterName = "@NgayThue",Value = receipt.NgayThue },
        //        new SqlParameter{ParameterName = "@TenKhach",Value = receipt.TenKhach},
        //   };
        //    string query = "update HopDongThuePhong set MaPhong =@MaPhong,MaKhach=@MaKhach,NgayThue=NgayThue,TenKhach=@TenKhach Where MaHopDong=@MaThue";
        //    DBHelper.Instance.ExecuteDB(query, para);
        //}
    }
}
