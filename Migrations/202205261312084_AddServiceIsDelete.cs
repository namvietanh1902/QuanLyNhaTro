namespace QuanLyNhaTro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddServiceIsDelete : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Rooms", new[] { "Name" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Rooms", "Name", unique: true);
        }
    }
}
