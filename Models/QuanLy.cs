using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace QuanLyNhaTro.Models
{
    public class QuanLy : DbContext
    {   
        

        public QuanLy() : base("name = PBL3") {
            Database.SetInitializer<QuanLy> (new DropCreateDatabaseIfModelChanges<QuanLy>());
        }

       
     
        private static QuanLy _instance;
        public static QuanLy Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new QuanLy();
                }
                return _instance;
            }
            private set { }
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<MonthlyReceipt> MonthlyReceipts { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServiceReceipt> ServiceReceipts { get; set; }
        public virtual DbSet<ServiceReceiptDetail> ServiceReceiptDetails { get; set; }
     

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //throw new UnintentionalCodeFirstException();
            modelBuilder.Entity<ServiceReceiptDetail>().
                HasKey(c => new { c.ServiceId,c.ServiceReceiptId})
                ;
            modelBuilder.Entity<Customer>()
                .HasRequired(c => c.Account).WithRequiredPrincipal(c => c.Customer);
            modelBuilder.Entity<Contract>()
                .HasRequired(c => c.Customer).WithRequiredPrincipal(c => c.Contract);
        }
    }
}
