namespace WeatherInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NFLDBContext2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "Player_PlayerId", c => c.Int());
            AddColumn("dbo.Players", "ImageId", c => c.Int(nullable: false));
            CreateIndex("dbo.Images", "Player_PlayerId");
            AddForeignKey("dbo.Images", "Player_PlayerId", "dbo.Players", "PlayerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "Player_PlayerId", "dbo.Players");
            DropIndex("dbo.Images", new[] { "Player_PlayerId" });
            DropColumn("dbo.Players", "ImageId");
            DropColumn("dbo.Images", "Player_PlayerId");
        }
    }
}
