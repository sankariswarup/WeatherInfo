namespace WeatherInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        PlayerPoS = c.String(),
                        PlayerNumber = c.String(),
                        PlayerName = c.String(),
                        PlayerStatus = c.String(),
                        statisticsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerId)
                .ForeignKey("dbo.Statistics", t => t.statisticsId, cascadeDelete: true)
                .Index(t => t.statisticsId);
            
            CreateTable(
                "dbo.Statistics",
                c => new
                    {
                        StatisticsId = c.Int(nullable: false, identity: true),
                        TeamOrPlayer = c.String(),
                        Wins = c.String(),
                        Losses = c.String(),
                        Rank = c.String(),
                    })
                .PrimaryKey(t => t.StatisticsId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        TeamPoS = c.String(),
                        TeamNumber = c.String(),
                        TeamName = c.String(),
                        TeamStatus = c.String(),
                        statisticsId = c.Int(nullable: false),
                        PlayerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeamId)
                .ForeignKey("dbo.Statistics", t => t.statisticsId, cascadeDelete: true)
                .Index(t => t.statisticsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teams", "statisticsId", "dbo.Statistics");
            DropForeignKey("dbo.Players", "statisticsId", "dbo.Statistics");
            DropIndex("dbo.Teams", new[] { "statisticsId" });
            DropIndex("dbo.Players", new[] { "statisticsId" });
            DropTable("dbo.Teams");
            DropTable("dbo.Statistics");
            DropTable("dbo.Players");
        }
    }
}
