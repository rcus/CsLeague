using CsLeague.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CsLeague.Controllers
{
    public class HomeController : Controller
    {
        private CsLeagueContext db = new CsLeagueContext();

        public ActionResult Index()
        {
            var scoreboard = db.Clans.ToList();
            return View(scoreboard.OrderByDescending(s => s.Points));
        }

        public ActionResult ClanPage(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var clanlist = db.Players.Where(c => c.Clans.Id == id).ToList();
            if (clanlist == null)
            {
                return HttpNotFound();
            }
            return View(clanlist.OrderByDescending(c => c.Score));
        }

        public ActionResult ClanTable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var p = db.Players.Find(id);
            var clanlist = db.Players.Where(c => c.Clans.Id == p.Clans.Id).ToList();
            if (clanlist == null)
            {
                return HttpNotFound();
            }
            return PartialView("_ClanData", clanlist.OrderByDescending(c => c.Score));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}