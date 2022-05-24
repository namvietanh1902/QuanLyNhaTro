
namespace QuanLyNhaTro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoomName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contracts", "CustomerName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contracts", "CustomerName");
        }
    }
}
