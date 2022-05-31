namespace QuanLyNhaTro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddisDelete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "isDelete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "isDelete");
        }
    }
}
