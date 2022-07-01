namespace QuanLyNhaTro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alo : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Accounts", new[] { "Username" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Accounts", "Username", unique: true);
        }
    }
}
