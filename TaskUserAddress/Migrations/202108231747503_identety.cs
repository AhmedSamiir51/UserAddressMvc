namespace TaskUserAddress.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class identety : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        IdUser = c.Int(nullable: false),
                        UserName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.IdUser);
            
            CreateTable(
                "dbo.UserAddresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false),
                        IdUser = c.Int(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.Users", t => t.IdUser, cascadeDelete: true)
                .Index(t => t.IdUser);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAddresses", "IdUser", "dbo.Users");
            DropIndex("dbo.UserAddresses", new[] { "IdUser" });
            DropTable("dbo.UserAddresses");
            DropTable("dbo.Users");
        }
    }
}
