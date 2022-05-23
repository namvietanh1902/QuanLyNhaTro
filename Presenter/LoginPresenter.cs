using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhaTro.Models;
using QuanLyNhaTro.Views;

namespace QuanLyNhaTro.Presenter
{
    public class LoginPresenter
    {
        private QuanLyKhachTroContext context;
        private ILoginView view;

        public LoginPresenter(QuanLyKhachTroContext context, ILoginView view)
        {
            this.context = context;
            this.view = view;
            view.LoginEvent += Login;
        }

        private void Login(object sender, EventArgs e)
        {
            
            var res = context.Accounts.Where(c => c.Username == view.Username && c.Password == view.Password).FirstOrDefault();
            if (res == null)
            {
                MessageBox.Show(
                   "Your username or password is incorrect ",
                   "Thông báo",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error
                   );
            }
            else
            {
                if (res.isAdmin)
                {   
                    
                    GiaodienAdmin frm= new GiaodienAdmin(res.AccountId);
                    frm.Show();
                }
                else
                {
                    GiaodienUser frm = new GiaodienUser(res.AccountId);
                    frm.Show();
                }

            }
        }
    }
}
