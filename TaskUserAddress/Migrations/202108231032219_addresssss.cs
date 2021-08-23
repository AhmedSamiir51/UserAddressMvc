namespace TaskUserAddress.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addresssss : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserAddresses", "Address2");
            DropColumn("dbo.UserAddresses", "Address3");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserAddresses", "Address3", c => c.String());
            AddColumn("dbo.UserAddresses", "Address2", c => c.String());
        }
    }
}
