namespace QuanLyNhaTro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false),
                        isAdmin = c.Boolean(nullable: false),
                        Name = c.String(),
                        Gender = c.Boolean(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        SDT = c.String(),
                        Customer_CustomerId = c.Int(),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .Index(t => t.Customer_CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Gender = c.Boolean(nullable: false),
                        CMND = c.String(nullable: false),
                        SDT = c.String(nullable: false),
                        Job = c.String(nullable: false),
                        AccountId = c.Int(nullable: false),
                        isDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        ContractId = c.Int(nullable: false, identity: true),
                        RoomID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ContractId)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomID, cascadeDelete: true)
                .Index(t => t.RoomID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Capacity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        isRent = c.Boolean(nullable: false),
                        isDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RoomId);
            
            CreateTable(
                "dbo.ServiceReceipts",
                c => new
                    {
                        ServiceReceiptId = c.Int(nullable: false, identity: true),
                        ContractID = c.Int(nullable: false),
                        PaidDate = c.DateTime(nullable: false),
                        Total = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceReceiptId)
                .ForeignKey("dbo.Contracts", t => t.ContractID, cascadeDelete: true)
                .Index(t => t.ContractID);
            
            CreateTable(
                "dbo.ServiceReceiptDetails",
                c => new
                    {
                        ServiceId = c.Int(nullable: false),
                        ServiceReceiptId = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ServiceId, t.ServiceReceiptId })
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceReceipts", t => t.ServiceReceiptId, cascadeDelete: true)
                .Index(t => t.ServiceId)
                .Index(t => t.ServiceReceiptId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Unit = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceId);
            
            CreateTable(
                "dbo.MonthlyReceipts",
                c => new
                    {
                        MonthlyReceiptId = c.Int(nullable: false, identity: true),
                        ContractID = c.Int(nullable: false),
                        Month = c.DateTime(nullable: false),
                        ElecBefore = c.Int(nullable: false),
                        WaterBefore = c.Int(nullable: false),
                        ElecAfter = c.Int(nullable: false),
                        WaterAfter = c.Int(nullable: false),
                        ElecBill = c.Int(nullable: false),
                        WaterBill = c.Int(nullable: false),
                        RoomBill = c.Int(nullable: false),
                        TotalBill = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MonthlyReceiptId)
                .ForeignKey("dbo.Contracts", t => t.ContractID, cascadeDelete: true)
                .Index(t => t.ContractID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MonthlyReceipts", "ContractID", "dbo.Contracts");
            DropForeignKey("dbo.ServiceReceiptDetails", "ServiceReceiptId", "dbo.ServiceReceipts");
            DropForeignKey("dbo.ServiceReceiptDetails", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.ServiceReceipts", "ContractID", "dbo.Contracts");
            DropForeignKey("dbo.Contracts", "RoomID", "dbo.Rooms");
            DropForeignKey("dbo.Contracts", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Accounts", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.MonthlyReceipts", new[] { "ContractID" });
            DropIndex("dbo.ServiceReceiptDetails", new[] { "ServiceReceiptId" });
            DropIndex("dbo.ServiceReceiptDetails", new[] { "ServiceId" });
            DropIndex("dbo.ServiceReceipts", new[] { "ContractID" });
            DropIndex("dbo.Contracts", new[] { "CustomerID" });
            DropIndex("dbo.Contracts", new[] { "RoomID" });
            DropIndex("dbo.Accounts", new[] { "Customer_CustomerId" });
            DropTable("dbo.MonthlyReceipts");
            DropTable("dbo.Services");
            DropTable("dbo.ServiceReceiptDetails");
            DropTable("dbo.ServiceReceipts");
            DropTable("dbo.Rooms");
            DropTable("dbo.Contracts");
            DropTable("dbo.Customers");
            DropTable("dbo.Accounts");
        }
    }
}
