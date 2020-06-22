using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forma1.Data.Models;
using Forma1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Forma1.Web.Controllers
{
    public class TeamController : Controller
    {
        private readonly string loginPagePath = "/Identity/Account/Login";

        private ITeamService teamService;
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        public TeamController(ITeamService teamService, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.teamService = teamService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        // GET: TeamController
        public ActionResult Index()
        {
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
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            return LocalRedirect(loginPagePath);
        }

        private IdentityUser GetCurrentUser()
        {
            return userManager.GetUserAsync(HttpContext.User).Result;
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
            if (User.Identity.IsAuthenticated)
            {
                var team = teamService.GetById(id);
                return View(team);
            }
            return LocalRedirect(loginPagePath);   
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
            if (User.Identity.IsAuthenticated)
            {
                var team = teamService.GetById(id);
                return View(team);
            }
            return LocalRedirect(loginPagePath);
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