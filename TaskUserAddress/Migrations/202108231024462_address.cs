namespace TaskUserAddress.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class address : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAddresses", "Address2", c => c.String());
            AddColumn("dbo.UserAddresses", "Address3", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserAddresses", "Address3");
            DropColumn("dbo.UserAddresses", "Address2");
        }
    }
}
