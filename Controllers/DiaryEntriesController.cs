using Microsoft.AspNetCore.Mvc;
using Diary.Models;

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
    }
}

