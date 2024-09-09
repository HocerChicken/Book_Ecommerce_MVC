using Book_Ecommerce_MVC.Data;
using Book_Ecommerce_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Book_Ecommerce_MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            this._db = db;
        }

        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category objCategory)
        {
            if (objCategory.Name == objCategory.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(objCategory);
                _db.SaveChanges();
                TempData["success"] = "Category Created Successfully!!!";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category objCategory)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(objCategory);
                _db.SaveChanges();
                TempData["success"] = "Category Updated Successfully!!!";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category objCategory = _db.Categories.Find(id);
            if (objCategory == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(objCategory);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted Successfully!!!";

            return RedirectToAction("Index");
        }
    }
}
