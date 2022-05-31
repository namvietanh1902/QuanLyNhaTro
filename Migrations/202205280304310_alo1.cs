namespace QuanLyNhaTro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alo1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Contracts", name: "CustomerId", newName: "ContractId");
            RenameIndex(table: "dbo.Contracts", name: "IX_CustomerId", newName: "IX_ContractId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Contracts", name: "IX_ContractId", newName: "IX_CustomerId");
            RenameColumn(table: "dbo.Contracts", name: "ContractId", newName: "CustomerId");
        }
    }
}
