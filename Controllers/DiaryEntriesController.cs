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
        [HttpGet] // this is not needed but just learning porpose
        public IActionResult Edit(int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            DiaryEntry? diaryEntry = _db.DiaryEntries.Find(id);
            if(diaryEntry == null)
            {
                return NotFound();
            }
            return View(diaryEntry);
        }

        [HttpPost]
        public IActionResult Edit(DiaryEntry obj)
        {
            // Server-side validation
            if(obj !=null && obj.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "Title too short");
            }
            // only if the data is valid 
            if(ModelState.IsValid)
            {
                _db.DiaryEntries.Update(obj); //Update the new diary entry to the database
                _db.SaveChanges(); // Saves the changes to the database
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet] 
        public IActionResult Delete(int? id)
        {
            if(id ==null || id == 0)
            {
                return NotFound();
            }
            DiaryEntry? diaryEntry = _db.DiaryEntries.Find(id);
            if(diaryEntry == null)
            {
                return NotFound();
            } 
        
            return View(diaryEntry);
        }
        [HttpPost] 
        public IActionResult Delete(DiaryEntry obj)
        {
            _db.DiaryEntries.Remove(obj); // Remove the diary entry from db
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
           
    }
}

