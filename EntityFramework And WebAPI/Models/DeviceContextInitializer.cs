using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Smart_House;

namespace EntityFramework_And_WebAPI.Models
{
    public class DeviceContextInitializer : DropCreateDatabaseAlways<DeviceContext>
    {
        ICreate Create = new CreateNew();
        protected override void Seed(DeviceContext context)
        {
            context.Fridges.Add(Create.NewFridge());
            context.Hoovers.Add(Create.NewHoover());
            context.Bicycles.Add(Create.NewBicycle());
            context.Televisions.Add(Create.NewTV());
            context.Warhammers.Add(Create.NewGame());
            context.SaveChanges();
            
        }
    }
}