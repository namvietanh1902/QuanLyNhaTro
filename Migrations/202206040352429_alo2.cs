namespace QuanLyNhaTro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alo2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceReceipts", "isPaid", c => c.Boolean(nullable: false));
            AddColumn("dbo.MonthlyReceipts", "isPaid", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MonthlyReceipts", "isPaid");
            DropColumn("dbo.ServiceReceipts", "isPaid");
        }
    }
}
