namespace QuanLyNhaTro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inheritance1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Receipts", "Contract_ContractId", "dbo.Contracts");
            DropIndex("dbo.Receipts", new[] { "Contract_ContractId" });
            DropColumn("dbo.Receipts", "Contract_ContractId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Receipts", "Contract_ContractId", c => c.Int());
            CreateIndex("dbo.Receipts", "Contract_ContractId");
            AddForeignKey("dbo.Receipts", "Contract_ContractId", "dbo.Contracts", "ContractId");
        }
    }
}
