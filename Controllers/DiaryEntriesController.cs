using Microsoft.AspNetCore.Mvc;
using Diary.Models;
using System.Diagnostics.Metrics;

namespace Diary.Controllers
{
    public class DiaryEntriesController : Controller
    {
        private readonly DiaryContext _db;

        // Constructor
        public DiaryEntriesController(DiaryContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            // Fetch diary entries from the database
            List<DiaryEntry> objDiaryEntryList = _db.DiaryEntries.ToList();

            // Pass the entries to the View
            return View(objDiaryEntryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DiaryEntry obj)
        {
            // Server-side validation
            if(obj !=null && obj.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "Title too short");
            }
            // only if the data is valid 
            if(ModelState.IsValid)
            {
                _db.DiaryEntries.Add(obj); //Adds the new diary entry to the database
                _db.SaveChanges(); // Saves the changes to the database
                return RedirectToAction("Index");
            }
            return View(obj);
           
        }
    }
}

