using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhaTro.Models;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace QuanLyNhaTro.DAO
{
    public  class DAL_KhachTro
    {
        private static DAL_KhachTro _instance;

        public static DAL_KhachTro Instance {
            get
            {
                if (_instance == null)
                {
                    _instance = new DAL_KhachTro();
                }
                return _instance;
            }
            private set { }
        }
        public List<CustomerModel> GetAllCustomer()
        {
            List<CustomerModel> res = new List<CustomerModel>();
            string query = "Select * from KhachTro";
            foreach (DataRow i in DBHelper.Instance.GetRecords(query, null).Rows)
            {
                res.Add(GetKhanhTroFromDataRow(i));
            }
            return res;
        }

        public CustomerModel GetKhanhTroFromDataRow(DataRow i)
        {
            string a = "2002-06-15";
            //string b = i["NgaySinh"].ToString();
            return new CustomerModel
            {                
                Id = Convert.ToInt32(i["UserId"].ToString()),
                Name = i["TenKhach"].ToString(),
                Gender = (i["GioiTinh"].ToString() == "True") ? true : false, // Gender bị lỗi nên phải cồng kềnh z :))
                CMND = i["CMND"].ToString(),
                SDT = i["SDT"].ToString(),
                MaKhach = Convert.ToInt32(i["MaKhach"].ToString()),
                NgheNghiep = i["NgheNghiep"].ToString(),
                //BirthDate bị lỗi không thể chuyển từ string sang DateTime?
                //BirthDate = DateTime.ParseExact(a, "yyyy-MM-dd", null)              
            };
        }

        public void AddCustomerFromSignin(string[] InfoCustomner) // them customer sau khi sign in
        {
            SqlParameter[] Param = new SqlParameter[3]; // Makhach & Name & UserID
            Param[0] = new SqlParameter("@MaKhach", GetAllCustomer().Count+1);  //ID = so luong + 1
            Param[1] = new SqlParameter("@Name", InfoCustomner[0]);
            Param[2] = new SqlParameter("@UserID", Convert.ToInt32(InfoCustomner[1]));
            string query = "Insert into KhachTro (MaKhach,TenKhach,UserID) values" +
                "(@MaKhach,@Name,@UserID)";
            DBHelper.Instance.ExecuteDB(query, Param);
        }

        public void ThayDoiThongTinUser(string[] InfoUser,bool Gender)
        {
            SqlParameter[] Param = new SqlParameter[6];
            Param[0] = new SqlParameter("@Name", InfoUser[0]);
            Param[1] = new SqlParameter("@Gender", Gender);
            //Param[2] = new SqlParameter("@Birth", InfoUser[2]);
            Param[2] = new SqlParameter("@SDT", InfoUser[1]);
            Param[3] = new SqlParameter("@CMND", InfoUser[2]);
            Param[4] = new SqlParameter("@Nghenghiep", InfoUser[3]);
            Param[5] = new SqlParameter("@UserID", InfoUser[4]);
            //string query = "Update KhachTro" +
            //    "set TenKhach=@Name,GioiTinh=@Gender,CMND=@CMND,SDT=@SDT,NgheNghiep=@Nghenghiep" +
            //    "where UserID = @UserID";
            string query = "UPDATE dbo.KhachTro" +
                " SET TenKhach=@Name,GioiTinh=@Gender,CMND=@CMND,SDT=@SDT,NgheNghiep=@Nghenghiep " +
                "where UserID = 12";
            DBHelper.Instance.ExecuteDB(query, Param);
        }

    }
}
