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

        public IActionResult Edit(int? id) 
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Setting? settingFromDb = _db.Settings.FirstOrDefault(u => u.Id == id); 

            if (settingFromDb == null)
            {
                return NotFound();
            }
            return View(settingFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Setting setting)
        {
            if (ModelState.IsValid)
            {
                _db.Settings.Update(setting);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(long? id)
        {
            //var setting = _db.Settings.Find(id);
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Setting? settingFromDb = _db.Settings.Find(id); // only works on primary key

            if (settingFromDb == null)
            {
                return NotFound();
            }
            return View(settingFromDb);

            //_db.Settings.Remove(setting);
            //_db.SaveChanges();

            //return RedirectToAction("Index");
        }
        [HttpPost, ActionName("Delete")] // action name is delete even ve have to give it an another name 
        public IActionResult DeletePOST(long? id)
        {
            Setting? setting = _db.Settings.Find(id);
            if (setting == null)
            {
                return NotFound();
            }
            _db.Settings.Remove(setting);
            _db.SaveChanges();
            
            return RedirectToAction("Index");
        }
    }
}

