using AsmAppDev2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Migrations;
using System.Web.Mvc;

namespace AsmAppDev2.Controllers
{
	public class HomeController : Controller
	{
		private ApplicationDbContext _context;
		public HomeController()
		{
			_context = new ApplicationDbContext();
		}
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			var profile = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
			var profileUser = profile.FindById(User.Identity.GetUserId());
			ViewBag.Name = profileUser.Full_Name;
			return View(profileUser);
		}
		[HttpGet]
		public ActionResult Edit(string id)
		{
			if (id == null)
			{
				return HttpNotFound();
			}
			var profile = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
			var profileUser = profile.FindById(User.Identity.GetUserId());
			if (profileUser == null)
			{
				return HttpNotFound();
			}
			return View(profileUser);
		}

		[HttpPost]
		public ActionResult Edit(ApplicationUser user)
		{
			var profile = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
			var profileUser = profile.FindById(User.Identity.GetUserId());
			if (profileUser == null)
			{
				return View(user);
			}

			if (ModelState.IsValid)
			{
				profileUser.Full_Name = user.Full_Name;
				profileUser.Working_Place = user.Working_Place;
				profileUser.PhoneNumber = user.PhoneNumber;
				profileUser.Email = user.Email;
				profileUser.Education = user.Education;
				profileUser.Programming_Language = user.Programming_Language;
				profileUser.Experience_Details = user.Experience_Details;
				profileUser.Department = user.Department;


				_context.Users.AddOrUpdate(profileUser);
				_context.SaveChanges();

				return RedirectToAction("About");
			}
			return View(user);

		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}