﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhaTro.Models;
using QuanLyNhaTro.BLL;
using QuanLyNhaTro.DTO;

namespace QuanLyNhaTro.Views
{
    public partial class GiaodienAdmin : Form
    {
        bool isthoat = true;
        public int ID { get; set; }
        public GiaodienAdmin(int id)
        {
            ID = id;
            InitializeComponent();
            hienthidulieulenthanhthongbao();
            cbbGioitinh_khachtro.Items.Clear();
            cbbGioitinh_khachtro.Items.Add("Nam");
            cbbGioitinh_khachtro.Items.Add("Nữ");
        }
        private void GiaodienAdmin_Load(object sender, EventArgs e)
        {
            lblUsername.Text = BLL_Account.Instance.GetNameByAccount(ID);
        }
        
        private void hienthidulieulenthanhthongbao()
        {
            string line = "";
            using (StreamReader sr = new StreamReader("..\\..\\Views\\DataThongbao.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    txtThongBao.Text += line + "\r\n";
                }
            }
        }

        private void btnLuuThongBao_Click(object sender, EventArgs e)
        {

            using (StreamWriter sw = new StreamWriter("..\\..\\Views\\DataThongbao.txt"))
            {
                sw.WriteLine(txtThongBao.Text);
                MessageBox.Show("Đã Lưu Thành Công!");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (isthoat)
            {
                Application.Exit();
            }
        }
        private void btnDangxuat_Click(object sender, EventArgs e)
        {
            isthoat = false;
            this.Close();
            DangNhap frm = new DangNhap();
            frm.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Home";
            lblHome.Visible = true;
            lblUser.Visible = false;
            lblKhachtro.Visible = false;
            lblPhongtro.Visible = false;
            lblDichvu.Visible = false;
            lblTinhtientro.Visible = false;
            lblThongke.Visible = false;
            pnHome.Visible = true;
            pnUser.Visible = false;
            pnKhanhtro.Visible = false;
            pnPhongtro.Visible = false;
            pnDichvu.Visible = false;
            pnTinhtientro.Visible = false;
            pnThongke.Visible = false;
        }

        private void reaload_user()
        {
            lblTitle.Text = "Manager User";
            lblHome.Visible = false;
            lblUser.Visible = true;
            lblKhachtro.Visible = false;
            lblPhongtro.Visible = false;
            lblDichvu.Visible = false;
            lblTinhtientro.Visible = false;
            lblThongke.Visible = false;
            pnHome.Visible = false;
            pnUser.Visible = true;
            pnKhanhtro.Visible = false;
            pnPhongtro.Visible = false;
            pnDichvu.Visible = false;
            pnTinhtientro.Visible = false;
            pnThongke.Visible = false;

            cbRoleuser.Items.Clear();
            cboSortUser_user.Items.Clear();
            cbRoleuser.Items.Add("Admin");
            cbRoleuser.Items.Add("Khach Tro");
            cboSortUser_user.Items.Add("AccountId");
            cboSortUser_user.Items.Add("Name");
            cboSortUser_user.Items.Add("Birthday");
            txtIduser_user.Text = BLL_Account.Instance.GetNextID().ToString();

            dgvthongtin_user.DataSource = BLL_Account.Instance.GetAccount_Views();
            foreach (DataGridViewColumn col in dgvthongtin_user.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                col.HeaderCell.Style.Font = new Font("Source Sans Pro", 14, FontStyle.Bold, GraphicsUnit.Pixel);
            }
            this.dgvthongtin_user.DefaultCellStyle.Font = new Font("Source Sans Pro", 10);
            dgvthongtin_user.ClearSelection();

        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            reaload_user();
        }

        private void cleardata_user()
        {
            dgvthongtin_user.ClearSelection();
            cbRoleuser.Enabled = true;
            txtIduser_user.Text = BLL_Account.Instance.GetNextID().ToString();
            txtUsername_User.Text = "";
            txtPass_user.Text = "";
            cbRoleuser.Text = "";
            txtName_User.Text = "";
            radNam.Checked = false;
            radNu.Checked = false;
            dtpNgaysinh_user.Value = DateTime.Now;
            txtSDT_user.Text = "";
        }

        private void btnLammoi_user_Click(object sender, EventArgs e)
        {
            cleardata_user();
        }  

        private void btnLuu_user_Click(object sender, EventArgs e)
        {
            try
            {
                Account account = new Account();
                account.AccountId = Convert.ToInt32(txtIduser_user.Text);
                account.Username = txtUsername_User.Text;
                if (txtPass_user.Text.Length < 6) throw new FormatException("mật khẩu phải dài trên 5 kí tự");
                else account.Password = txtPass_user.Text;
                if (cbRoleuser.SelectedIndex == 0)
                {
                    account.isAdmin = true;
                }
                else if (cbRoleuser.SelectedIndex == 1)
                {
                    account.isAdmin = false;
                }
                else if (cbRoleuser.SelectedIndex == -1)
                {
                    throw new FormatException("isAdmin không dc trống");
                }
                if (txtName_User.Text == "") throw new FormatException("Tên không được để trống");
                else account.Name = txtName_User.Text;
                if (radNam.Checked == true)
                {
                    account.Gender = true;
                }
                else if (radNu.Checked == true)
                {
                    account.Gender = false;
                }
                else throw new FormatException("Giới tính không dc trống");
                if (DateTime.Now.Year - dtpNgaysinh_user.Value.Year < 18) throw new FormatException("Tuổi dưới 18");
                else account.Birthday = dtpNgaysinh_user.Value;
                if (txtSDT_user.Text == "") throw new FormatException("Số điện thoại không dc để trống");
                if (txtSDT_user.Text.Length != 10) throw new FormatException("Số điện thoại phải có 10 số");
                long sdt;
                if (long.TryParse(txtSDT_user.Text, out sdt))
                {
                    account.SDT = txtSDT_user.Text;
                }
                else throw new FormatException("Số điện thoại phải là số");

                if (dgvthongtin_user.SelectedRows.Count < 1) //add
                {
                    BLL_Account.Instance.AddAccount(account);
                    if (account.isAdmin == false)
                    {
                        foreach (Account acc in BLL_Account.Instance.GetAllAccount())
                        {
                            if (acc.SDT == account.SDT)
                            {
                                txtTennguoithue_khachtro.Text = acc.Name;
                                txtSDT_khachtro.Text = acc.SDT;
                                txtMakhachtro_khachtro.Text = acc.AccountId.ToString();
                                if (acc.Gender == true)
                                {
                                    cbbGioitinh_khachtro.SelectedItem = "Nam";
                                }
                                else
                                    cbbGioitinh_khachtro.SelectedItem = "Nữ";
                                dtpNgaysinh_khachtro.Value = acc.Birthday;
                                break;
                            }
                        }
                    }
                }
                if (dgvthongtin_user.SelectedRows.Count == 1)//update
                {
                    account.AccountId = Convert.ToInt32(txtIduser_user.Text);
                    BLL_Account.Instance.UpdateAccount(account);
                    cbRoleuser.Enabled = true;

                    foreach (Customer customer in BLL_Customer.Instance.GetAllCustomer())
                    {
                        if (customer.CustomerId == account.AccountId)
                        {
                            Customer cus = new Customer();
                            cus.CustomerId = customer.CustomerId;
                            cus.Name = account.Name;
                            cus.Gender = account.Gender;
                            cus.CMND = customer.CMND;
                            cus.SDT = account.SDT;
                            cus.Job = customer.Job;
                            cus.CustomerId = customer.CustomerId;
                            cus.Birthday = account.Birthday;
                            BLL_Customer.Instance.UpdateKhachTro(cus);
                            break;
                        }
                    }



                    Contract contract = new Contract();
                    foreach (Contract hd in BLL_Contract.Instance.GetAllContract())
                    {
                        foreach (Customer cus in BLL_Customer.Instance.GetAllCustomer())
                        {
                            if (cus.CustomerId == hd.ContractId)
                            {
                                contract.ContractId = hd.ContractId;
                                contract.RoomId = hd.RoomId;
                                contract.CreatedAt = hd.CreatedAt;
                                contract.CustomerName = cus.Name;
                                break;
                            }
                        }
                    }
                    BLL_Contract.Instance.UpdateContract(contract);
                }
                cleardata_user();
                reaload_user();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            


        }

        private void btnSuathongtinuser_Click(object sender, EventArgs e)
        {
            cbRoleuser.Enabled = false;
            txtIduser_user.Text = dgvthongtin_user.SelectedRows[0].Cells["AccountId"].Value.ToString();
            txtUsername_User.Text = dgvthongtin_user.SelectedRows[0].Cells["Username"].Value.ToString();
            txtPass_user.Text = dgvthongtin_user.SelectedRows[0].Cells["Password"].Value.ToString();

            if (Convert.ToBoolean(dgvthongtin_user.SelectedRows[0].Cells["isAdmin"].Value.ToString()) == true)
            {
                cbRoleuser.SelectedItem = "Admin";
            }
            else
            {
                cbRoleuser.SelectedItem = "Khach Tro";
            }
            txtName_User.Text = dgvthongtin_user.SelectedRows[0].Cells["Name"].Value.ToString();
            if (Convert.ToBoolean(dgvthongtin_user.SelectedRows[0].Cells["Gender"].Value.ToString()) == true)
            {
                radNam.Checked = true;
            }
            else
            {
                radNu.Checked = true;
            }
            dtpNgaysinh_user.Value = Convert.ToDateTime(dgvthongtin_user.SelectedRows[0].Cells["Birthday"].Value.ToString());
            txtSDT_user.Text = dgvthongtin_user.SelectedRows[0].Cells["SDT"].Value.ToString();
        }

        private void btnXoa_user_Click(object sender, EventArgs e)
        {
            List<int> listIDdell = new List<int>();
            if (dgvthongtin_user.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvthongtin_user.SelectedRows)
                {
                    listIDdell.Add(Convert.ToInt32(row.Cells["AccountId"].Value.ToString()));
                }
            }
            BLL_Account.Instance.DeleteAccount(listIDdell);

            foreach(int id in listIDdell)
            {
                if(id == ID)
                {
                    btnDangxuat.PerformClick();
                }
            }
            BLL_Customer.Instance.DeleteKhachTro(listIDdell);



            cleardata_user();
            dgvthongtin_user.DataSource = BLL_Account.Instance.GetAccount_Views();
            dgvthongtin_user.ClearSelection();
        }

        private void btnsearch_user_Click(object sender, EventArgs e)
        {
            dgvthongtin_user.DataSource = BLL_Account.Instance.SearchAccount(txtSearch_user.Text);
        }

        private void btnSort_user_Click(object sender, EventArgs e)
        {
            List<int> listnow = new List<int>();
            foreach (DataGridViewRow row in dgvthongtin_user.Rows)
            {
                listnow.Add(Convert.ToInt32(row.Cells["AccountId"].Value.ToString()));
            }
            dgvthongtin_user.DataSource = BLL_Account.Instance.SortAccount(listnow, cboSortUser_user.SelectedItem.ToString());
        }


        private void click_khanhtro()
        {
            lblTitle.Text = "Quản Lý Khách Trọ";
            lblHome.Visible = false;
            lblUser.Visible = false;
            lblKhachtro.Visible = true;
            lblPhongtro.Visible = false;
            lblDichvu.Visible = false;
            lblTinhtientro.Visible = false;
            lblThongke.Visible = false;
            pnHome.Visible = false;
            pnUser.Visible = false;
            pnKhanhtro.Visible = true;
            pnPhongtro.Visible = false;
            pnDichvu.Visible = false;
            pnTinhtientro.Visible = false;
            pnThongke.Visible = false;


        }

        private void reloadkhachtro()
        {
            cbbSort_khachtro.Items.Clear();
            cbbSort_khachtro.Items.Add("CustomerId");
            cbbSort_khachtro.Items.Add("Name");
            cbbSort_khachtro.Items.Add("Birthday");
            cbbTenphongtro_khanhtro.Items.Clear();
            cbbTenphongtro_khanhtro.Items.AddRange(BLL_Room.Instance.GetRoomEmtyAndNoFullUpCombobox().ToArray());
            dgvthongtin_khachtro.DataSource = BLL_Customer.Instance.GetCustomer_Views();
            this.dgvthongtin_khachtro.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvthongtin_khachtro.DefaultCellStyle.Font = new Font("Source Sans Pro", 10);
            foreach (DataGridViewColumn col in dgvthongtin_khachtro.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                col.HeaderCell.Style.Font = new Font("Source Sans Pro", 14, FontStyle.Bold, GraphicsUnit.Pixel);
            }
           // txtMakhachtro_khachtro.Text = BLL_Customer.Instance.GetNextID().ToString();
            txtMakhachtro_khachtro.ReadOnly = true;
            dgvthongtin_khachtro.ClearSelection();
        }

        private void cleardata_khachtro()
        {
            dgvthongtin_khachtro.ClearSelection();
            txtMakhachtro_khachtro.Text = "";
            txtTennguoithue_khachtro.Text = "";
            txtCmnd_khachtro.Text = "";
            txtSDT_khachtro.Text = "";
            txtNghenghiep_khachtro.Text = "";
            dtpNgaysinh_khachtro.Value = DateTime.Now;
            cbbGioitinh_khachtro.Text = "";
            cbbTenphongtro_khanhtro.Text = "";

        }
        private void btnKhachtro_Click(object sender, EventArgs e)
        {
            cleardata_user();
            click_khanhtro();
            reloadkhachtro();
        }



        private void btnLuukhachtro_Click(object sender, EventArgs e)
        {
            try
            {
                if(cbbTenphongtro_khanhtro.SelectedIndex == -1) throw new FormatException("Tên phòng không dc để trống");
                Customer cusAdd = new Customer();
                if (txtTennguoithue_khachtro.Text == "") throw new FormatException("Tên không được để trống");
                else cusAdd.Name = txtTennguoithue_khachtro.Text;
                if (DateTime.Now.Year - dtpNgaysinh_khachtro.Value.Year < 18) throw new FormatException("Tuổi dưới 18");
                else cusAdd.Birthday = dtpNgaysinh_khachtro.Value;
                if (cbbGioitinh_khachtro.SelectedIndex == 0) cusAdd.Gender = true;
                else if (cbbGioitinh_khachtro.SelectedIndex == 1) cusAdd.Gender = false;
                else if (cbbGioitinh_khachtro.SelectedIndex == -1)
                    throw new FormatException("Giới tính không dc để trống");
                if (txtCmnd_khachtro.Text == "") throw new FormatException("CMND không dc để trống");
                long cmnd;
                if (long.TryParse(txtCmnd_khachtro.Text, out cmnd))
                {
                    cusAdd.CMND = txtCmnd_khachtro.Text;
                }
                else throw new FormatException("CMND phải là số");
                if (txtSDT_khachtro.Text == "") throw new FormatException("Số điện thoại không dc để trống");
                if (txtSDT_khachtro.Text.Length != 10) throw new FormatException("Số điện thoại phải có 10 số");
                long sdt;
                if (long.TryParse(txtSDT_khachtro.Text, out sdt))
                {
                    cusAdd.SDT = txtSDT_khachtro.Text;
                }
                else throw new FormatException("Số điện thoại phải là số");
                if (txtNghenghiep_khachtro.Text == "") throw new FormatException("Nghề nghiệp không dc để trống");
                else cusAdd.Job = txtNghenghiep_khachtro.Text;

                if (dgvthongtin_khachtro.SelectedRows.Count < 1) //add
                {
                    if (BLL_Account.Instance.CheckSDT(txtSDT_khachtro.Text))
                    {
                        foreach (Account acc in BLL_Account.Instance.GetAllAccount())
                        {
                            if (acc.SDT == txtSDT_khachtro.Text && acc.isAdmin == false && acc.isDelete == false)
                            {
                                cusAdd.CustomerId = acc.AccountId;
                                break;
                            }
                        }
                        BLL_Customer.Instance.AddKhachTro(cusAdd);
                        foreach (Customer cus in BLL_Customer.Instance.GetAllCustomer())
                        {
                            if (cus.CustomerId == cusAdd.CustomerId)
                            {
                                Contract contract = new Contract();
                                contract.ContractId = cus.CustomerId;
                                foreach (Room phong in BLL_Room.Instance.GetAllRoom())
                                {
                                    if (phong.Name == cbbTenphongtro_khanhtro.SelectedItem.ToString())
                                    {
                                        contract.RoomId = phong.RoomId;
                                        break;
                                    }
                                }
                                contract.CustomerName = cus.Name;
                                BLL_Contract.Instance.AddContract(contract);
                                foreach (Room room in BLL_Room.Instance.GetAllRoom())
                                {
                                    if (room.isRent == false && contract.RoomId == room.RoomId)
                                    {
                                        room.isRent = true;
                                        BLL_Room.Instance.UpdateIsRentRoomWhenAddCustomer(room);
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(
                           "Bạn chưa có tài khoản," +
                           "Bẩm OK để chuyển tiếp đến giao diện tạo tài khoản",
                           "Thông báo",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information
                           );
                        txtName_User.Text = txtTennguoithue_khachtro.Text;
                        txtSDT_user.Text = txtSDT_khachtro.Text;
                        dtpNgaysinh_user.Value = dtpNgaysinh_khachtro.Value;
                        if (cbbGioitinh_khachtro.SelectedItem.ToString() == "Nam")
                        {
                            radNam.Checked = true;
                        }
                        else radNu.Checked = true;
                        btnUser.PerformClick();
                    }
                }


                if (dgvthongtin_khachtro.SelectedRows.Count == 1) //update
                {
                    cusAdd.CustomerId = Convert.ToInt32(txtMakhachtro_khachtro.Text);
                    Account account = new Account();
                    foreach (Customer cus in BLL_Customer.Instance.GetAllCustomer())
                    {
                        if (cus.CustomerId == cusAdd.CustomerId)
                        {
                            cusAdd.CustomerId = cus.CustomerId;
                            break;
                        }
                    }

                    BLL_Customer.Instance.UpdateKhachTro(cusAdd);

                    foreach (Account acc in BLL_Account.Instance.GetAllAccount())
                    {
                        if (acc.AccountId == cusAdd.CustomerId)
                        {
                            account.AccountId = acc.AccountId;
                            account.Username = acc.Username;
                            account.Password = acc.Password;
                            account.isAdmin = acc.isAdmin;
                            account.Name = cusAdd.Name;
                            account.Gender = cusAdd.Gender;
                            account.Birthday = cusAdd.Birthday;
                            account.SDT = cusAdd.SDT;
                            break;
                        }
                    }
                    BLL_Account.Instance.UpdateAccount(account);

                    Contract contract = new Contract();
                    foreach (Contract hd in BLL_Contract.Instance.GetAllContract())
                    {
                        if (hd.ContractId == cusAdd.CustomerId)
                        {
                            contract.ContractId = hd.ContractId;
                            contract.RoomId = hd.RoomId;
                            contract.CreatedAt = hd.CreatedAt;
                            contract.CustomerName = cusAdd.Name;
                            break;
                        }
                    }
                    BLL_Contract.Instance.UpdateContract(contract);
                }
                reloadkhachtro();
                cleardata_khachtro();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnLammoi_khachtro_Click(object sender, EventArgs e)
        {
            cleardata_khachtro();
        }

        private void btnSua_khachtro_Click(object sender, EventArgs e)
        {

            txtMakhachtro_khachtro.Text = dgvthongtin_khachtro.SelectedRows[0].Cells["CustomerId"].Value.ToString();
            txtTennguoithue_khachtro.Text = dgvthongtin_khachtro.SelectedRows[0].Cells["Name"].Value.ToString();
            txtCmnd_khachtro.Text = dgvthongtin_khachtro.SelectedRows[0].Cells["CMND"].Value.ToString();
            txtSDT_khachtro.Text = dgvthongtin_khachtro.SelectedRows[0].Cells["SDT"].Value.ToString();
            txtNghenghiep_khachtro.Text = dgvthongtin_khachtro.SelectedRows[0].Cells["Job"].Value.ToString();
            dtpNgaysinh_khachtro.Value = Convert.ToDateTime(dgvthongtin_khachtro.SelectedRows[0].Cells["Birthday"].Value.ToString());
            foreach (CBBItems r in cbbTenphongtro_khanhtro.Items)
            {
                if (r.Text == dgvthongtin_khachtro.SelectedRows[0].Cells["RoomName"].Value.ToString())
                {
                    cbbTenphongtro_khanhtro.SelectedItem = r;
                }
            }
            if (Convert.ToBoolean(dgvthongtin_khachtro.SelectedRows[0].Cells["Gender"].Value.ToString()) == true)
            {
                cbbGioitinh_khachtro.SelectedItem = "Nam";
            }
            else cbbGioitinh_khachtro.SelectedItem = "Nữ";
        }

        private void btnXoa_khachtro_Click(object sender, EventArgs e)
        {
            List<int> listMaKhachdel = new List<int>();
            if (dgvthongtin_khachtro.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvthongtin_khachtro.SelectedRows)
                {
                    listMaKhachdel.Add(Convert.ToInt32(row.Cells["CustomerId"].Value.ToString()));
                }
            }
            BLL_Customer.Instance.DeleteKhachTro(listMaKhachdel);
            List<int> listUserIDdel = new List<int>();
            foreach (Customer cus in BLL_Customer.Instance.GetAllCustomer())
            {
                foreach (int makhach in listMaKhachdel)
                {
                    if (cus.CustomerId == makhach)
                    {
                        listUserIDdel.Add(cus.CustomerId);
                    }
                }
            }
            BLL_Account.Instance.DeleteAccount(listUserIDdel);
            BLL_Room.Instance.ResetisRent();
            reloadkhachtro();




        }

        private void btnSearch_khachtro_Click(object sender, EventArgs e)
        {
            dgvthongtin_khachtro.DataSource = BLL_Customer.Instance.SearchKhachTro(txtSearch_khachtro.Text);
            dgvthongtin_khachtro.ClearSelection();
        }

        private void btnSort_khachtro_Click(object sender, EventArgs e)
        {
            List<int> listnow = new List<int>();
            foreach (DataGridViewRow i in dgvthongtin_khachtro.Rows)
            {
                listnow.Add(Convert.ToInt32(i.Cells["CustomerId"].Value.ToString()));
            }
            dgvthongtin_khachtro.DataSource = BLL_Customer.Instance.SortKhachTro(listnow, cbbSort_khachtro.SelectedItem.ToString());
            dgvthongtin_khachtro.ClearSelection();
        }
        private void lblreload_phongtro_Click(object sender, EventArgs e)
        {
            reaload_phongtro();
        }

        private void reaload_phongtro()
        {
            CBBItems All = new CBBItems
            {
                Text = "All",
                Value = 0
            };
            cbbSort_phongtro.Items.Clear();
            cbbStatus.Items.Clear();
            cbbCap.Items.Clear();
            cbbPrice.Items.Clear();
            cbbSort_phongtro.Items.AddRange(new object[]
            {
                "Giá phòng",
                "Số người ở"

            });
            cbbPrice.Items.Add(All);

            foreach (int i in BLL_Room.Instance.GetAllPriceTags())
            {
                cbbPrice.Items.Add(new CBBItems { Text = i.ToString(), Value = i });
            }
            cbbCap.Items.Add(All);
            foreach (int i in BLL_Room.Instance.GetAllRoomCapacity())
            {
                cbbCap.Items.Add(new CBBItems { Text = i.ToString(), Value = i });
            }
            cbbStatus.Items.AddRange(new CBBItems[]
            {
                All,
                new CBBItems{Text = "Phòng trống",Value =1},
                new CBBItems{Text = "Phòng chưa đầy",Value =2},

                new CBBItems{Text = "Phòng đầy",Value =3},
            });
            cbbCap.SelectedIndex = 0;
            cbbPrice.SelectedIndex = 0;
            cbbStatus.SelectedIndex = 0;
            cbbSort_phongtro.SelectedIndex = 0;

            dgvThongtin_phongtro.DataSource = BLL_Room.Instance.GetRoom_Views(BLL_Room.Instance.GetAllRoom());
            foreach (DataGridViewColumn col in dgvThongtin_phongtro.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                col.HeaderCell.Style.Font = new Font("Source Sans Pro", 14, FontStyle.Bold, GraphicsUnit.Pixel);
            }
            this.dgvThongtin_phongtro.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvThongtin_phongtro.DefaultCellStyle.Font = new Font("Source Sans Pro", 10);
            dgvThongtin_phongtro.ClearSelection();
        }

        private void btnPhongtro_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Quản Lý Phòng Trọ";
            lblHome.Visible = false;
            lblUser.Visible = false;
            lblKhachtro.Visible = false;
            lblPhongtro.Visible = true;
            lblDichvu.Visible = false;
            lblTinhtientro.Visible = false;
            lblThongke.Visible = false;
            pnHome.Visible = false;
            pnUser.Visible = false;
            pnKhanhtro.Visible = false;
            pnPhongtro.Visible = true;
            pnDichvu.Visible = false;
            pnTinhtientro.Visible = false;
            pnThongke.Visible = false;
            reaload_phongtro();
        }
   

        private void btnChitietphongthue_phongtro_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(dgvThongtin_phongtro.SelectedRows[0].Cells["isRent"].Value.ToString()))
            {
                int ma = Convert.ToInt32(dgvThongtin_phongtro.SelectedRows[0].Cells["RoomId"].Value.ToString());
                ChiTietPhongThue frm = new ChiTietPhongThue(ma);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Phòng này trống");
            }
        }

        private void btnThemPhongTro_Click(object sender, EventArgs e)
        {
            int x = BLL_Room.Instance.GetNextID();
            ThemPhongTro frm = new ThemPhongTro(BLL_Room.Instance.GetNextID());
            frm.d += new ThemPhongTro.Mydel(reaload_phongtro); 

            frm.ShowDialog();
        }
        private void btnSuaPhongTro_Click(object sender, EventArgs e)
        {
            if (dgvThongtin_phongtro.SelectedRows.Count == 1)
            {
                int ma = Convert.ToInt32(dgvThongtin_phongtro.SelectedRows[0].Cells["RoomId"].Value.ToString());
                ThemPhongTro frm = new ThemPhongTro(ma);
                frm.d += new ThemPhongTro.Mydel(reaload_phongtro);
                frm.ShowDialog();
            }
        }
        private void btnXoa_phongtro_Click(object sender, EventArgs e)
        {
            List<int> listdel = new List<int>();
            foreach (DataGridViewRow row in dgvThongtin_phongtro.SelectedRows)
            {
                listdel.Add(Convert.ToInt32(row.Cells["RoomId"].Value.ToString()));
            }
            BLL_Room.Instance.DeletePhongTro(listdel);
            reaload_phongtro();
        }

        private void btnSort_phongtro_Click(object sender, EventArgs e)
        {

            dgvThongtin_phongtro.DataSource = BLL_Room.Instance.RoomSort(GetCurrentList(), cbbSort_phongtro.SelectedItem.ToString());
        }
        List<string> GetCurrentList()
        {
            List<string> listnow = new List<string>();
            foreach (DataGridViewRow i in dgvThongtin_phongtro.Rows)
            {
                listnow.Add(i.Cells["RoomId"].Value.ToString());
            }
            return listnow;

        }

        private void btnSearch_phongtro_Click(object sender, EventArgs e)
        {
            int Price = ((CBBItems)cbbPrice.SelectedItem).Value;
            int Cap = ((CBBItems)cbbCap.SelectedItem).Value;
            int Status = ((CBBItems)cbbStatus.SelectedItem).Value;
            dgvThongtin_phongtro.DataSource = BLL_Room.Instance.SearchRoom(Status, Price, Cap);
            dgvThongtin_phongtro.ClearSelection();
        }

        private void btnDichvu_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Quản Lý Dịch Vụ";
            lblHome.Visible = false;
            lblUser.Visible = false;
            lblKhachtro.Visible = false;
            lblPhongtro.Visible = false;
            lblDichvu.Visible = true;
            lblTinhtientro.Visible = false;
            lblThongke.Visible = false;
            pnHome.Visible = false;
            pnUser.Visible = false;
            pnKhanhtro.Visible = false;
            pnPhongtro.Visible = false;
            pnDichvu.Visible = true;
            pnTinhtientro.Visible = false;
            pnThongke.Visible = false;
            reload_Service();
        }
        private void reload_Service()
        {
            dgvService.DataSource = BLL_Service.Instance.SearchService(txtSearch_Service.Text);
            cbbSort_Service.Items.Clear();
            cbbSort_Service.Items.AddRange(new object[] {
                "Tên",
                "Giá dịch vụ"
            });
            cbbSort_Service.SelectedIndex = 0;
            foreach (DataGridViewColumn col in dgvService.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                col.HeaderCell.Style.Font = new Font("Source Sans Pro", 14, FontStyle.Bold, GraphicsUnit.Pixel);
            }
            this.dgvService.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvService.DefaultCellStyle.Font = new Font("Source Sans Pro", 10);
            Reset_Service();
            txtServiceID.ReadOnly = true;
            isEdit_Service = false;
            dgvService.ClearSelection();
        }
        public void Reset_Service()
        {
            txtServiceID.Text = BLL_Service.Instance.GetNextID().ToString();
            txtServiceName.Text = "";
            txtServiceUnit.Text = "";
            txtServicePrice.Text = "";
        }
        bool isEdit_Service { get; set; } = false;
        private void btnReset_Service_Click(object sender, EventArgs e)
        {
            Reset_Service();
        }
        private void btnEdit_Service_Click(object sender, EventArgs e)
        {
            if (dgvService.SelectedRows.Count == 1)
            {
                isEdit_Service = true;
                txtServiceID.Text = dgvService.SelectedRows[0].Cells["ServiceID"].Value.ToString();
                txtServiceName.Text = dgvService.SelectedRows[0].Cells["Name"].Value.ToString();
                txtServiceUnit.Text = dgvService.SelectedRows[0].Cells["Unit"].Value.ToString();
                txtServicePrice.Text = dgvService.SelectedRows[0].Cells["Price"].Value.ToString();
            }
        }

        private void btnSave_Service_Click(object sender, EventArgs e)
        {
            try
            {
                int Price;
                if (!Int32.TryParse(txtServicePrice.Text, out Price))
                {
                    throw new Exception("Giá phải là số");
                }
                Service service = new Service
                {
                    ServiceId = Convert.ToInt32(txtServiceID.Text),
                    Name = txtServiceName.Text,
                    Unit = txtServiceUnit.Text,
                    Price = Price
                };
                new BLL.Common.ModelDataValidation().Validate(service);
            
            BLL_Service.Instance.AddOrUpdate(isEdit_Service, service);
            reload_Service();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Thông báo lỗi");
            }

        }
        private void btnDelete_Service_Click(object sender, EventArgs e)
        {
            if (dgvService.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow i in dgvService.SelectedRows)
                {
                    BLL_Service.Instance.DeleteService(Convert.ToInt32(i.Cells["ServiceID"].Value.ToString()));
                }
                reload_Service();
            }

        }

        private void btnSearch_Service_Click(object sender, EventArgs e)
        {
            dgvService.DataSource = BLL_Service.Instance.SearchService(txtSearch_Service.Text);

        }

        private void btnSort_Service_Click(object sender, EventArgs e)
        {
            List<int> list = new List<int>();
            foreach (DataGridViewRow i in dgvService.Rows)
            {
                list.Add(Convert.ToInt32(i.Cells["ServiceId"].Value.ToString()));
            }
            dgvService.DataSource = BLL_Service.Instance.Sort(list, cbbSort_Service.SelectedItem.ToString());
            dgvService.ClearSelection();
        }


        private void btnTinhtientro_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Tính Tiền Trọ";
            lblHome.Visible = false;
            lblUser.Visible = false;
            lblKhachtro.Visible = false;
            lblPhongtro.Visible = false;
            lblDichvu.Visible = false;
            lblTinhtientro.Visible = true;
            lblThongke.Visible = false;
            pnHome.Visible = false;
            pnUser.Visible = false;
            pnKhanhtro.Visible = false;
            pnPhongtro.Visible = false;
            pnDichvu.Visible = false;
            pnTinhtientro.Visible = true;
            pnThongke.Visible = false;
            reload_ThanhToan();
        }

        private void btnThongke_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Thống Kê";
            lblHome.Visible = false;
            lblUser.Visible = false;
            lblKhachtro.Visible = false;
            lblPhongtro.Visible = false;
            lblDichvu.Visible = false;
            lblTinhtientro.Visible = false;
            lblThongke.Visible = true;
            pnHome.Visible = false;
            pnUser.Visible = false;
            pnKhanhtro.Visible = false;
            pnPhongtro.Visible = false;
            pnDichvu.Visible = false;
            pnTinhtientro.Visible = false;
            pnThongke.Visible = true;
        }

        private void btnNav_Click(object sender, EventArgs e)
        {
            if (pnNavagation.Width == 288)
            {
                pnNavagation.Width = 86;
                lblHethong.Text = "";
                btnDangxuat.Location = new Point(8, 791);
                btnDangxuat.Text = "";
                btnDangxuat.Width = 70;
                pnTongdoanhthu.Location = new Point(505, 31);
                pictureBox1.Visible = false;
                btnDangxuat.ImageIndex = 0;
            }
            else
            {
                pictureBox1.Visible = true;
                pnTongdoanhthu.Location = new Point(510, 32);
                btnDangxuat.Location = new Point(-25, 791);
                btnDangxuat.Text = "Đăng xuất";
                btnDangxuat.Width = 125;
                pnNavagation.Width = 288;
                lblHethong.Text = "HỆ THỐNG";
                btnDangxuat.ImageIndex = -1;

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Home";
            lblHome.Visible = true;
            lblUser.Visible = false;
            lblKhachtro.Visible = false;
            lblPhongtro.Visible = false;
            lblDichvu.Visible = false;
            lblTinhtientro.Visible = false;
            lblThongke.Visible = false;
            pnHome.Visible = true;
            pnUser.Visible = false;
            pnKhanhtro.Visible = false;
            pnPhongtro.Visible = false;
            pnDichvu.Visible = false;
            pnTinhtientro.Visible = false;
            pnThongke.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_Service_TextChanged(object sender, EventArgs e)
        {
            dgvService.DataSource = BLL_Service.Instance.SearchService(txtSearch_Service.Text);
        }
        private void reload_ThanhToan()
        {
            foreach (Customer i in BLL_Customer.Instance.GetAllCustomer())
            {
                if (i.isDelete == false)
                {
                    cbbCustomer.Items.Add(new CBBItems
                    {
                        Text = i.Name,
                        Value = i.CustomerId,
                    });
                }
            }
            
           
            
           
            txtRoomID_Month.Enabled = false;
            txtRoomName_Month.Enabled = false;
            txtCusID_ThanhToan.Enabled = false;
            txtCusName_ThanhToan.Enabled = false;
            txtCusSDT.Enabled = false;
            txtCusCCCD.Enabled = false;
            txtCusJob.Enabled = false;
            txtGender.Enabled = false;
            RentDate.Enabled = false;
            birthDate.Enabled = false;
            cbbCustomer.SelectedIndex = 0;
            txtPrice.Enabled = false;
            txtElecAfter.Text = "";
            txtElecFirst.Text = "";
            txtElecPrice.Text = "";
            txtWaterAfter.Text = "";
            txtWaterFirst.Text = "";
            txtWaterPrice.Text = "";

        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            int ElecBefore = Convert.ToInt32(txtElecFirst.Text);
            int ElecAfter = Convert.ToInt32(txtElecAfter.Text);
            int WaterBefore = Convert.ToInt32(txtWaterFirst.Text);
            int WaterAfter = Convert.ToInt32(txtWaterAfter.Text);
            int WaterPrice = Convert.ToInt32(txtWaterPrice.Text);
            int ElecPrice = Convert.ToInt32(txtElecPrice.Text);
            MonthlyReceipt receipt = new MonthlyReceipt
            {
                ContractID = ((CBBItems)cbbCustomer.SelectedItem).Value,
                Month = Month.Value,
                ElecBefore = ElecBefore,
                ElecAfter = ElecAfter,
                WaterBefore= WaterBefore,
                WaterAfter = WaterAfter,
                WaterBill = (WaterAfter -WaterBefore)*WaterPrice,
                ElecBill = (ElecAfter - ElecBefore)*ElecPrice,
                RoomBill = Convert.ToInt32(txtPrice.Text),
                
        };
            receipt.Total = receipt.ElecBill + receipt.WaterBill + receipt.RoomBill;
            MessageBox.Show("Số tiền khách phải trả là: "+ receipt.Total);
            BLL_Receipt.Instance.AddMonthlyReceipt(receipt);
            reload_ThanhToan();
        }
        private void GUI()
        {
            int i = ((CBBItems)cbbCustomer.SelectedItem).Value;
            Customer data = BLL_Customer.Instance.GetCustomerByID(i);
            txtRoomID_Month.Text = data.Contract.Room.RoomId.ToString();
            txtCusID_ThanhToan.Text = i.ToString();
            txtRoomName_Month.Text = data.Contract.Room.Name;
            txtGender.Text= data.Gender ? "Nam" : "Nữ";
            txtCusName_ThanhToan.Text = data.Name;
            txtCusSDT.Text = data.SDT;
            txtCusCCCD.Text= data.CMND;
            txtCusJob.Text = data.Job;
            RentDate.Value = (DateTime)data.Contract.CreatedAt;
            birthDate.Value = (DateTime)data.Birthday;
            txtPrice.Text = data.Contract.Room.Price.ToString();

        }
        private void cbbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            GUI();
        }
    }
}


