using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Smart_House;

namespace EntityFramework_And_WebAPI.Models
{
    public class DeviceContext : DbContext
    {
        static DeviceContext()
        {
            System.Data.Entity.Database.SetInitializer<DeviceContext>(new DeviceContextInitializer());
        }
        public DbSet<Fridge> Fridges { get; set; }
        public DbSet<Hoover> Hoovers { get; set; }
        public DbSet<StationaryBicycle> Bicycles { get; set; }
        public DbSet<Television> Televisions { get; set; }
        public DbSet<Warhammer> Warhammers { get; set; }
    }
}