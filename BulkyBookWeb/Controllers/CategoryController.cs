using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db; // local _db instance

        public CategoryController(ApplicationDbContext db) // dependency injection allows to "pull in" already made db with application context
        {
            _db = db; // assign local to the ApplicationDbContext db
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories; // get the category table entries and assign to IEnumerable of type Category.
            return View(objCategoryList);
        }
    }
}
