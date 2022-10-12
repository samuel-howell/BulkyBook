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


        // NOTE: when modifying controller, must rebuild application. When modifying views, you can just hot reload.


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
            // server side validation
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match the Name."); // the first param is name, bc we are adding the error to the name property specifically.
            }
            if (ModelState.IsValid) // makes sure data matches the required fields in the Category Model (ex. name must not be null). that way we don't crash the db inserting faulty data.
            {
                _db.Categories.Add(obj); // add new category obj from form to to the Categories table in the database
                _db.SaveChanges(); // save the database to "lock in" the new category obj
                TempData["success"] = "Category created successfully"; // assign key name succes to Tempdata
                return RedirectToAction("Index"); // sends us back to index view (the view with the category list)
            }
            return View(obj);
        }

        // GET action method
        public IActionResult Edit(int? id) // retreive id, and get other details of category based on that id
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id); // finds based on primary key, which we know is id
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id); // will not throw exception if more than one elem found. have top pass generic Category object u
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id); // will throw exception if there are more than one elem found

            if(categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        // POST action method
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult Edit(Category obj)
        {
            // server side validation
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match the Name."); // the first param is name, bc we are adding the error to the name property specifically.
            }
            if (ModelState.IsValid) 
            {
                _db.Categories.Update(obj); 
                _db.SaveChanges(); 
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index"); 
            }
            return View(obj);
        }


        // GET action method
        public IActionResult Delete(int? id) // retreive id, and get other details of category based on that id
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id); // finds based on primary key, which we know is id
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id); // will not throw exception if more than one elem found. have top pass generic Category object u
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id); // will throw exception if there are more than one elem found

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        // POST action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Categories.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
                
            _db.Categories.Remove(obj); 
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index"); 
            
           
        }
    }
}
