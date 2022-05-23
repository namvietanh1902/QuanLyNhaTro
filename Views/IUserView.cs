using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaTro.Views
{
    public interface IUserView
    {
        int AccountID { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        bool Gender { get; set; }
        string Name { get; set; }
        DateTime BirthDay { get; set; }
        string SDT { get; set; }
        string SearchValue { get; set; }
        string SortType { get; set; }
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler LoadDataIntoEdit;
        event EventHandler ResetEvent;
        event EventHandler SearchEvent;
        event EventHandler SortEvent;

        //Methods
        void SetAccountBindingSource(BindingSource accountList);

    }
}
