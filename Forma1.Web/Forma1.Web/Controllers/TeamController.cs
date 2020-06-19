using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forma1.Data.Models;
using Forma1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forma1.Web.Controllers
{
    public class TeamController : Controller
    {
        private ITeamService teamService;

        public TeamController(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        // GET: TeamController
        public ActionResult Index()
        {

            //teamService.Add(new Team() { Name = "Kecske" });
            //teamService.Add(new Team() { Name = "Kecske2" });

            var teams = teamService.GetAll();
            return View(teams);
        }

        // GET: TeamController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TeamController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeamController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Team team)
        {
            try
            {
                teamService.Add(team);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeamController/Edit/5
        public ActionResult Edit(int id)
        {
            var team = teamService.GetById(id);
            return View(team);
        }

        // POST: TeamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Team team)
        {
            try
            {
                teamService.Update(team);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeamController/Delete/5
        public ActionResult Delete(int id)
        {
            var team = teamService.GetById(id);
            return View(team);
        }

        // POST: TeamController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Team team)
        {
            try
            {
                teamService.RemoveById(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
