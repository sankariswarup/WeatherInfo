namespace WeatherInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NFLDBContext1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "ImageData", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "ImageData");
        }
    }
}
