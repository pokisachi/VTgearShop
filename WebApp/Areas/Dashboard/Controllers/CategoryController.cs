using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Controllers;

namespace WebApp.Areas.Dashboard.Controllers;
[Area("dashboard")]
public class CategoryController : BaseController
{
    // Hiển thị danh sách danh mục
    public IActionResult Index()
    {
        var categories = Provider.Category.GetCategories();
        return View(categories);
    }

    // Hiển thị form thêm mới
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Category category, IFormFile? ImageFile)
    {
        if (ModelState.IsValid)
        {
            try
            {
                // Kiểm tra và lưu ảnh nếu có
                if (ImageFile != null && ImageFile.ContentType.StartsWith("image/"))
                {
                    string fileName = Path.GetFileName(ImageFile.FileName);
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/categories", fileName);

                    // Lưu file ảnh vào thư mục
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        ImageFile.CopyTo(stream);
                    }

                    category.ImageUrl = fileName; // Lưu đường dẫn ảnh
                }

                Provider.Category.AddCategory(category); // Thêm vào DB
                TempData["Message"] = "Category added successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error: {ex.Message}";
            }
        }
        return View(category); // Trả về form nếu lỗi
    }

    // Hiển thị form chỉnh sửa
    public IActionResult Edit(short id)
    {
        var category = Provider.Category.GetCategory(id);
        if (category == null)
        {
            TempData["Error"] = "Category not found.";
            return RedirectToAction("Index");
        }
        return View(category);
    }

     [HttpPost]
   public IActionResult Edit(short id, Category obj){
        obj.CategoryId = id;
        int ret = Provider.Category.UpdateCategory(obj);
        if(ret > 0){
            return Redirect("/dashboard/category/index");
        }
        ModelState.AddModelError("Error","Update failed");
        return View(obj);
    }






    // Xóa danh mục
    public IActionResult Delete(short id)
    {
        try
        {
            var category = Provider.Category.GetCategory(id);
            if (category == null)
            {
                TempData["Error"] = "Category not found.";
                return RedirectToAction("Index");
            }
        

            Provider.Category.DeleteCategory(id); // Xóa khỏi DB
            TempData["Message"] = "Category deleted successfully!";
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Error: {ex.Message}";
        }

        return RedirectToAction("Index");
    }
}
