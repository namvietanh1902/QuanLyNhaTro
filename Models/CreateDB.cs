using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace QuanLyNhaTro.Models
{
    public class CreateDB : DropCreateDatabaseIfModelChanges<QuanLy> 
    {
        protected override void Seed(QuanLy context)
        {
            context.Accounts.Add(new Account { AccountId = 1, Username = "NamAnh", Password = "123456", isAdmin = true ,Gender=true, Birthday = DateTime.Today, Name = "Nam Anh", SDT = "0333825874"});
        }
    }
}
