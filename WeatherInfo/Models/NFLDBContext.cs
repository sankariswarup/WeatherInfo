using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WeatherInfo.Models
{
    public class NFLDBContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public NFLDBContext() : base("name=NFLDBContext")
        {
        }

        public System.Data.Entity.DbSet<WeatherInfo.Models.Player> Players { get; set; }

        public System.Data.Entity.DbSet<WeatherInfo.Models.Statistics> Statistics { get; set; }

        public System.Data.Entity.DbSet<WeatherInfo.Models.Team> Teams { get; set; }

        public System.Data.Entity.DbSet<WeatherInfo.Models.Image> Images { get; set; }
    
    }
}
