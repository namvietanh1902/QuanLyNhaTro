namespace QuanLyNhaTro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsDeleteToService : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "isDelete", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Accounts", "Username", unique: true);
           
        }
        
        public override void Down()
        {
            
            DropIndex("dbo.Accounts", new[] { "Username" });
            DropColumn("dbo.Services", "isDelete");
        }
    }
}
