using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Smart_House;
using EntityFramework_And_WebAPI.Models;

namespace EntityFramework_And_WebAPI.Controllers
{
    public class fridgeController : ApiController
    {
        private DeviceContext db = new DeviceContext();
        // api/fridge
    
        // PUT api/fridge/5
        [Route("api/fridge/{button}/{id}")]
        public string Put(int id, string button)
        {
            Device dev = db.Fridges.Find(id);
            if (dev != null)
            {

                switch (button)
                {
                    case "on":
                        dev.On();
                        break;
                }
            }
            db.SaveChanges();
            return dev.ToString();
        }

        // DELETE api/fridge/5
        public void Delete(int id)
        {
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
