using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace QuanLyNhaTro.Models
{
    public class QuanLyKhachTroContext : DbContext
    {   
        
        public QuanLyKhachTroContext() : base("name = PBL3") { }

       
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
            
        }
    }
}
