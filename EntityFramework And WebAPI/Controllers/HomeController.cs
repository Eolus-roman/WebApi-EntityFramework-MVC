using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Smart_House;
using EntityFramework_And_WebAPI.Models;

namespace EntityFramework_And_WebAPI.Controllers
{
    public class HomeController : Controller
    {
        private DeviceContext db = new DeviceContext();
        IChangeEnum ice;
        IVolume iv;
        IOpenOrClose iooc;
        IResetSettings irs;
        ISpeed isp;
        IUse iu;
        public ActionResult Index()
        {
            SelectListItem[] devicesList = new SelectListItem[5];
            devicesList[0] = new SelectListItem { Text = "Hoover", Value = "HO", Selected = true };
            devicesList[1] = new SelectListItem { Text = "Fridge", Value = "FR" };
            devicesList[2] = new SelectListItem { Text = "Bicycle", Value = "BI" };
            devicesList[3] = new SelectListItem { Text = "Television", Value = "TV" };
            devicesList[4] = new SelectListItem { Text = "Warhammer", Value = "WH" };
            ViewBag.DevicesList = devicesList;
            ViewBag.Title = "Smart House MVC";
            List<Device> dev = GetDevices(db);

            return View(dev);
        }
        public static List<Device> GetDevices(DeviceContext db)
        {
            List<Device> dev = db.Hoovers.ToList().Cast<Device>().ToList();
            dev.AddRange(db.Fridges.ToList().Cast<Device>().ToList());
            dev.AddRange(db.Bicycles.ToList().Cast<Device>());
            dev.AddRange(db.Televisions.ToList().Cast<Device>());
            dev.AddRange(db.Warhammers.ToList().Cast<Device>());
            return dev;
        }
        public ActionResult Add(string deviceType)
        {
            Device newDevice;
            ICreate Create = new CreateNew();
            switch (deviceType)
            {
                default:
                    newDevice = Create.NewHoover();
                    db.Hoovers.Add((Hoover)newDevice);
                    break;
                case "FR":
                    newDevice = Create.NewFridge();
                    db.Fridges.Add((Fridge)newDevice);
                    break;
                case "BI":
                    newDevice = Create.NewBicycle();
                    db.Bicycles.Add((StationaryBicycle)newDevice);
                    break;
                case "TV":
                    newDevice = Create.NewTV();
                    db.Televisions.Add((Television)newDevice);
                    break;
                case "WH":
                    newDevice = Create.NewGame();
                    db.Warhammers.Add((Warhammer)newDevice);
                    break;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Operation(string type, string id, string command)
        {
            Device d = GetDevice(type, id);
            if (d == null)
            {
                return HttpNotFound();
            }
            if (d.Type == "Fridge")
            {
                iooc = (IOpenOrClose)d;
                ice = (IChangeEnum)d;
            }
            if (d.Type == "Hoover")
            {
                irs = (IResetSettings)d;
                iu = (IUse)d;
                ice = (IChangeEnum)d;
            }
            if (d.Type == "Bicycle")
            {
                isp = (ISpeed)d;
                irs = (IResetSettings)d;
                ice = (IChangeEnum)d;
            }
            if (d.Type == "Television")
            {
                ice = (IChangeEnum)d;
                iv = (IVolume)d;
            }
            if (d.Type == "Warhammer")
            {
                ice = (IChangeEnum)d;
                iu = (IUse)d;
            }
            switch (command)
            {
                case "on":
                    d.On();
                    break;
                case "off":
                    d.Off();
                    break;
                case "previous":
                    ice.PreviousEnum();
                    break;
                case "next":
                    ice.NextEnum();
                    break;
                case "minus":
                    iv.MinusVolume();
                    break;
                case "plus":
                    iv.PlusVolume();
                    break;
                case "open":
                    iooc.Open();
                    break;
                case "close":
                    iooc.Close();
                    break;
                case "rfp":
                    irs.ResetFirstParameter();
                    break;
                case "rsp":
                    irs.ResetSecondParameter();
                    break;
                case "low":
                    isp.Low();
                    break;
                case "unh":
                    isp.Unhurriedly();
                    break;
                case "boost":
                    isp.Boost();
                    break;
                case "quick":
                    isp.Quick();
                    break;
                case "app":
                    iu.Apply();
                    break;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(string type, string id)
        {
            Device d = GetDevice(type, id);
            if (d == null)
            {
                return HttpNotFound();
            }
            switch (type)
            {
                case "Hoover":
                    db.Hoovers.Remove((Hoover)d);
                    break;
                case "Fridge":
                    db.Fridges.Remove((Fridge)d);
                    break;
                case "Bicycle":
                    db.Bicycles.Remove((StationaryBicycle)d);
                    break;
                case "Television":
                    db.Televisions.Remove((Television)d);
                    break;
                case "Warhammer":
                    db.Warhammers.Remove((Warhammer)d);
                    break;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        private Device GetDevice(string type, string id)
        {
            int idDev;
            if (!int.TryParse(id, out idDev))
            {
                return null;
            }
            switch (type)
            {
                case "Hoover":
                    return db.Hoovers.Find(idDev);
                case "Fridge":
                    return db.Fridges.Find(idDev);
                case "Bicycle":
                    return db.Bicycles.Find(idDev);
                case "Television":
                    return db.Televisions.Find(idDev);
                case "Warhammer":
                    return db.Warhammers.Find(idDev);
                default:
                    return null;
            }
        }
    }

}

