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
    public class DAL_KhachTro
    {
        private static DAL_KhachTro _instance;

        public static DAL_KhachTro Instance
        {
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
    //    public List<CustomerModel> GetAllCustomer()
    //    {
    //        List<CustomerModel> res = new List<CustomerModel>();
    //        string query = "Select * from KhachTro";
    //        foreach (DataRow i in DBHelper.Instance.GetRecords(query, null).Rows)
    //        {
    //            res.Add(GetKhanhTroFromDataRow(i));
    //        }
    //        return res;
    //    }

    //    public CustomerModel GetKhanhTroFromDataRow(DataRow i)
    //    {
    //        return new CustomerModel
    //        {
    //            UserID = Convert.ToInt32(i["UserID"].ToString()),
    //            MaKhach = Convert.ToInt32(i["MaKhach"].ToString()),
    //            TenKhach = i["TenKhach"].ToString(),
    //            BirthDate = Convert.ToDateTime(i["NgaySinh"].ToString()),
    //            Gender = Convert.ToBoolean(i["GioiTinh"].ToString()),
    //            CMND = i["CMND"].ToString(),
    //            SDT = i["SDT"].ToString(),
    //            NgheNghiep = i["NgheNghiep"].ToString(),
    //            MaPhong = Convert.ToInt32(i["MaPhong"].ToString()),
    //        };
    //    }

    //    //public void AddCustomerFromSignin(string[] InfoCustomner) // them customer sau khi sign in
    //    //{
    //    //    SqlParameter[] Param = new SqlParameter[3]; // Makhach & Name & UserID
    //    //    Param[0] = new SqlParameter("@MaKhach", GetAllCustomer().Count+1);  //ID = so luong + 1
    //    //    Param[1] = new SqlParameter("@Name", InfoCustomner[0]);
    //    //    Param[2] = new SqlParameter("@UserID", Convert.ToInt32(InfoCustomner[1]));
    //    //    string query = "Insert into KhachTro (MaKhach,TenKhach,UserID) values" +
    //    //        "(@MaKhach,@Name,@UserID)";
    //    //    DBHelper.Instance.ExecuteDB(query, Param);
    //    //}

    //    public void ThayDoiThongTinUser(string[] InfoUser, bool Gender)
    //    {
    //        SqlParameter[] Param = new SqlParameter[6];
    //        Param[0] = new SqlParameter("@Name", InfoUser[0]);
    //        Param[1] = new SqlParameter("@Gender", Gender);
    //        //Param[2] = new SqlParameter("@Birth", InfoUser[2]);
    //        Param[2] = new SqlParameter("@SDT", InfoUser[1]);
    //        Param[3] = new SqlParameter("@CMND", InfoUser[2]);
    //        Param[4] = new SqlParameter("@Nghenghiep", InfoUser[3]);
    //        Param[5] = new SqlParameter("@UserID", InfoUser[4]);
    //        //string query = "Update KhachTro" +
    //        //    "set TenKhach=@Name,GioiTinh=@Gender,CMND=@CMND,SDT=@SDT,NgheNghiep=@Nghenghiep" +
    //        //    "where UserID = @UserID";
    //        string query = "UPDATE dbo.KhachTro" +
    //            " SET TenKhach=@Name,GioiTinh=@Gender,CMND=@CMND,SDT=@SDT,NgheNghiep=@Nghenghiep " +
    //            "where UserID = 12";
    //        DBHelper.Instance.ExecuteDB(query, Param);
    //    }


    //    public DataTable ShowAllInfoKhanhTro()
    //    {
    //        string query = "Select MaKhach,TenKhach,PhongTro.TenPhong,NgaySinh,GioiTinh,CMND,SDT,NgheNghiep from KhachTro " +
    //            "inner join PhongTro on KhachTro.MaPhong = PhongTro.MaPhong";
    //        return DBHelper.Instance.GetRecords(query, null);
    //    }

    //    public void AddKhachTro(CustomerModel cus)
    //    {
    //        SqlParameter[] para = new SqlParameter[]
    //        {
    //            new SqlParameter{ParameterName = "@Ten",Value =cus.TenKhach },
    //            new SqlParameter{ParameterName = "@MaPhong",Value = cus.MaPhong },
    //            new SqlParameter{ParameterName = "@NgaySinh",Value = cus.BirthDate},
    //            new SqlParameter{ParameterName = "@GioiTinh",Value = cus.Gender },
    //            new SqlParameter{ParameterName = "@CMND",Value = cus.CMND},
    //            new SqlParameter{ParameterName = "@SDT",Value = cus.SDT},
    //            new SqlParameter{ParameterName = "@NgheNghiep",Value = cus.NgheNghiep},
    //        };
    //        string query = "insert into KhachTro(TenKhach,MaPhong,NgaySinh,GioiTinh,CMND,SDT,NgheNghiep) values (@Ten,@MaPhong,@NgaySinh,@GioiTinh,@CMND,@SDT,@NgheNghiep)";
    //        DBHelper.Instance.ExecuteDB(query, para);
    //    }

    //    public void UpdateIDOfKhachTro(CustomerModel cus)
    //    {
    //        string query = "update KhachTro set UserID = " + cus.UserID + " where SDT = " + cus.SDT;
    //        DBHelper.Instance.ExecuteDB(query, null);
    //    }

    //    public void UpdateKhachTro(CustomerModel cus)
    //    {
    //        SqlParameter[] para = new SqlParameter[]
    //        {
    //            new SqlParameter{ParameterName = "@MaKhach",Value =cus.MaKhach },
    //            new SqlParameter{ParameterName = "@Ten",Value =cus.TenKhach },
    //            new SqlParameter{ParameterName = "@MaPhong",Value = cus.MaPhong },
    //            new SqlParameter{ParameterName = "@NgaySinh",Value = cus.BirthDate},
    //            new SqlParameter{ParameterName = "@GioiTinh",Value = cus.Gender },
    //            new SqlParameter{ParameterName = "@CMND",Value = cus.CMND},
    //            new SqlParameter{ParameterName = "@SDT",Value = cus.SDT},
    //            new SqlParameter{ParameterName = "@NgheNghiep",Value = cus.NgheNghiep},
    //        };
    //        string query = "update KhachTro set TenKhach=@Ten,MaPhong=@MaPhong,NgaySinh=@NgaySinh,GioiTinh=@GioiTinh,CMND=@CMND,SDT=@SDT,NgheNghiep=@NgheNghiep where MaKhach = @MaKhach ";
    //        DBHelper.Instance.ExecuteDB(query, para);
    //    }


    //    public void DeleteKhachTro(int MaKhach)
    //    {
    //        string query = "delete from KhachTro where MaKhach =" + MaKhach;
    //        DBHelper.Instance.ExecuteDB(query, null);
    //    }

    //    public DataTable SearchKhachTro(string txt)
    //    {
    //        string query = "select MaKhach, TenKhach, PhongTro.TenPhong,NgaySinh,GioiTinh,CMND,SDT,NgheNghiep " +
    //            "from KhachTro inner join PhongTro on KhachTro.MaPhong = PhongTro.MaPhong  where TenKhach like N'%" + txt + "%'";
    //        return DBHelper.Instance.GetRecords(query, null);
    //    }

    //    public DataTable SortKhachTro(List<int> makhach, string SortType)
    //    {
    //        DataTable datasortAll = new DataTable();
    //        string query = "select MaKhach, TenKhach, PhongTro.TenPhong,NgaySinh,GioiTinh,CMND,SDT,NgheNghiep " +
    //             "from KhachTro inner join PhongTro on KhachTro.MaPhong = PhongTro.MaPhong ORDER BY " + SortType;
    //        datasortAll = DBHelper.Instance.GetRecords(query, null);


    //        //    foreach (int ma in makhach.ToList())
    //        //    {
    //        //        foreach (DataRow row in datasortAll.Rows)
    //        //        {
    //        //              if (Convert.ToInt32(row[0].ToString()) != ma)
    //        //            {
    //        //                    datasortAll.Rows.Remove(row);
    //        //            }
    //        //    }
    //        //}

    //        return datasortAll;
    //    }
    }
}
