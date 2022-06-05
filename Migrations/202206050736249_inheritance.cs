namespace QuanLyNhaTro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inheritance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountId = c.Int(nullable: false),
                        Username = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false),
                        isAdmin = c.Boolean(nullable: false),
                        Name = c.String(),
                        Gender = c.Boolean(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        SDT = c.String(),
                        isDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AccountId)
                .Index(t => t.Username, unique: true);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        Gender = c.Boolean(nullable: false),
                        CMND = c.String(nullable: false),
                        SDT = c.String(nullable: false),
                        Job = c.String(nullable: false),
                        isDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Accounts", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        ContractId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        CustomerName = c.String(),
                    })
                .PrimaryKey(t => t.ContractId)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.ContractId)
                .Index(t => t.ContractId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Capacity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        isRent = c.Boolean(nullable: false),
                        isDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RoomId);
            
            CreateTable(
                "dbo.Receipts",
                c => new
                    {
                        ReceiptID = c.Int(nullable: false, identity: true),
                        ContractID = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                        isPaid = c.Boolean(nullable: false),
                        PaidDate = c.DateTime(),
                        Month = c.DateTime(),
                        ElecBefore = c.Int(),
                        WaterBefore = c.Int(),
                        ElecAfter = c.Int(),
                        WaterAfter = c.Int(),
                        ElecBill = c.Int(),
                        WaterBill = c.Int(),
                        RoomBill = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Contract_ContractId = c.Int(),
                    })
                .PrimaryKey(t => t.ReceiptID)
                .ForeignKey("dbo.Contracts", t => t.Contract_ContractId)
                .ForeignKey("dbo.Contracts", t => t.ContractID, cascadeDelete: true)
                .Index(t => t.ContractID)
                .Index(t => t.Contract_ContractId);
            
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
                .ForeignKey("dbo.Receipts", t => t.ServiceReceiptId, cascadeDelete: true)
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
                        isDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Receipts", "ContractID", "dbo.Contracts");
            DropForeignKey("dbo.Customers", "CustomerId", "dbo.Accounts");
            DropForeignKey("dbo.Contracts", "ContractId", "dbo.Customers");
            DropForeignKey("dbo.Receipts", "Contract_ContractId", "dbo.Contracts");
            DropForeignKey("dbo.ServiceReceiptDetails", "ServiceReceiptId", "dbo.Receipts");
            DropForeignKey("dbo.ServiceReceiptDetails", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.Contracts", "RoomId", "dbo.Rooms");
            DropIndex("dbo.ServiceReceiptDetails", new[] { "ServiceReceiptId" });
            DropIndex("dbo.ServiceReceiptDetails", new[] { "ServiceId" });
            DropIndex("dbo.Receipts", new[] { "Contract_ContractId" });
            DropIndex("dbo.Receipts", new[] { "ContractID" });
            DropIndex("dbo.Contracts", new[] { "RoomId" });
            DropIndex("dbo.Contracts", new[] { "ContractId" });
            DropIndex("dbo.Customers", new[] { "CustomerId" });
            DropIndex("dbo.Accounts", new[] { "Username" });
            DropTable("dbo.Services");
            DropTable("dbo.ServiceReceiptDetails");
            DropTable("dbo.Receipts");
            DropTable("dbo.Rooms");
            DropTable("dbo.Contracts");
            DropTable("dbo.Customers");
            DropTable("dbo.Accounts");
        }
    }
}
