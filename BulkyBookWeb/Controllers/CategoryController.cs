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

        // GET action method
        public IActionResult Create()
        {
            return View();
        }

        // POST action method
        [HttpPost]
        [ValidateAntiForgeryToken] // inside any forms it will automaticcally inject key that will be validated 
        public IActionResult Create(Category obj)
        {
            _db.Categories.Add(obj); // add new category obj from form to to the Categories table in the database
            _db.SaveChanges(); // save the database to "lock in" the new category obj
            return RedirectToAction("Index"); // sends us back to index view (the view with the category list)
        }
    }
}
