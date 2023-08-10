using DemoProject.Models;
using DemoProject.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Controllers
{
	public class SettingController : Controller
	{
		private readonly ApplicationDbContext _db;

		public SettingController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
            
            List<Setting> setting = _db.Settings.ToList();
            return View(setting);

		}
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Setting setting)
		{
			if (ModelState.IsValid)
			{
				_db.Settings.Add(setting);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View("Index");
		}

	}
}

