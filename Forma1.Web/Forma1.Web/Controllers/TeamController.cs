using Forma1.Data.Models;
using Forma1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Forma1.Web.Controllers
{
    public class TeamController : Controller
    {
        private readonly string _loginPagePath = "/Identity/Account/Login";

        private ITeamService _teamService;
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;

        public TeamController(ITeamService teamService,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _teamService = teamService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: TeamController
        public ActionResult Index()
        {
            var teams = _teamService.GetAll();
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
            return LocalRedirect(_loginPagePath);
        }

        private IdentityUser GetCurrentUser()
        {
            return _userManager.GetUserAsync(HttpContext.User).Result;
        }

        // POST: TeamController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Team team)
        {
            try
            {
                _teamService.Add(team);
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
                var team = _teamService.GetById(id);
                return View(team);
            }
            return LocalRedirect(_loginPagePath);   
        }

        // POST: TeamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Team team)
        {
            try
            {
                _teamService.Update(team);
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
                var team = _teamService.GetById(id);
                return View(team);
            }
            return LocalRedirect(_loginPagePath);
        }

        // POST: TeamController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Team team)
        {
            try
            {
                _teamService.RemoveById(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}