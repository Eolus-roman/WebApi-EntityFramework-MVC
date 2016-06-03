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
    public class HooverController : ApiController
    {
        private DeviceContext db = new DeviceContext();
        IChangeEnum ce;
        IResetSettings irs;
        IUse iu;
        // PUT api/hoover/5
        [Route("api/hoover/{command}/{id}")]
        public string Put(string command, int id)
        {
            Device dev = db.Hoovers.Find(id);
            ce = (IChangeEnum)dev;
            if (dev != null)
            {
                switch (command)
                {
                    case "on":
                        dev.On();
                        break;
                    case "off":
                        dev.Off();
                        break;
                    case "previous":
                        ce.PreviousEnum();
                        break;
                    case "next":
                        ce.NextEnum();
                        break;
                    case "rfp":
                        irs.ResetFirstParameter();
                        break;
                    case "rsp":
                        irs.ResetSecondParameter();
                        break;
                    case "app":
                        iu.Apply();
                        break;
                }
            }
            db.SaveChanges();
            return dev.ToString();
        }

        // DELETE api/hoover/5
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
