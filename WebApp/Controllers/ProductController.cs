using Microsoft.AspNetCore.Mvc;




    namespace WebApp.Controllers;

    public class ProductController : BaseController
    {
        // Hiển thị danh sách sản phẩm
        public IActionResult Index()
        {
            ViewBag.Categories = Provider.Category.GetCategories(); // Lấy danh sách danh mục
            return View(Provider.Product.GetProducts()); // Trả về danh sách sản phẩm
        }

        // Hiển thị sản phẩm theo danh mục
        public IActionResult Category(short id)
        {
            ViewBag.Categories = Provider.Category.GetCategories(); // Lấy danh sách danh mục
            ViewBag.Category = Provider.Category.GetCategory(id); // Lấy thông tin danh mục hiện tại
            return View(Provider.Product.GetProductsByCategory(id)); // Lấy sản phẩm theo danh mục
        }

        // Hiển thị chi tiết một sản phẩm
        public IActionResult Details(int id)
        {
            ViewBag.Categories = Provider.Category.GetCategories(); // Lấy danh sách danh mục
            Product? product = Provider.Product.GetProduct(id); // Lấy chi tiết sản phẩm
            if (product is null)
            {
                return Redirect("/"); // Nếu không tìm thấy sản phẩm, chuyển hướng về trang chủ
            }
            ViewBag.Product = product; // Gán sản phẩm vào ViewBag
            return View(Provider.Product.GetProductsRelation(product.CategoryId, id)); // Sản phẩm liên quan
        }

        // Hiển thị danh sách nhà cung cấp
        public IActionResult Supplier()
        {
            ViewBag.Categories = Provider.Category.GetCategories(); // Lấy danh sách danh mục
            return View(Provider.Supplier.GetSuppliers()); // Lấy danh sách nhà cung cấp
        }

        // Hiển thị chi tiết nhà cung cấp
        public IActionResult SupplierDetails(string id)
        {
            ViewBag.Suppliers = Provider.Supplier.GetSuppliers(); // Lấy danh sách nhà cung cấp
            ViewBag.Supplier = Provider.Supplier.GetSupplier(id); // Lấy thông tin nhà cung cấp hiện tại
            return View(); // Trả về View hiển thị chi tiết nhà cung cấp
        }

        public IActionResult Add()
        {
            return View();
        }
    private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

 [HttpPost]
public IActionResult Add(Product obj, IFormFile? ImageFile)
{
    if (ImageFile != null && ImageFile.Length > 0)
    {
        // Xử lý upload file
        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images/products", fileName);

        // Lưu file vào thư mục
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            ImageFile.CopyTo(stream);
        }

        // Gán tên file vào thuộc tính Image
        obj.Image = fileName;
    }
    else
    {
        // Nếu không có file, gán hình ảnh mặc định
        obj.Image = "default.jpg";
    }

    // Lưu đối tượng Product vào database
    int result = Provider.Product.Add(obj);
    return RedirectToAction("Index");
}



       public IActionResult Delete(int id){
            bool isDeleted = Provider.Product.DeleteProduct(id); // Xóa sản phẩm
            if (isDeleted)
            {
                TempData["Message"] = "Product deleted successfully!"; // Hiển thị thông báo nếu xóa thành công
            }
            else
            {
                TempData["Error"] = "Failed to delete the product.";
            }
            return RedirectToAction("Index"); // Quay về danh sách sản phẩm
        }

        // Hiển thị form chỉnh sửa sản phẩm
        public IActionResult Edit(int id)
        {
            Product? product = Provider.Product.GetProduct(id); // Lấy sản phẩm theo ID
            if (product == null)
            {
                TempData["Error"] = "Product not found.";
                return RedirectToAction("Index");
            }
            return View(product); // Trả về View chỉnh sửa
        }

        // Xử lý lưu chỉnh sửa
        [HttpPost]
        public IActionResult Edit(Product product, IFormFile? ImageFile)
        {
            // Xử lý upload hình ảnh nếu có
            if (ImageFile != null)
            {
                string imagePath = Path.Combine("wwwroot/images/products", ImageFile.FileName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    ImageFile.CopyTo(stream);
                }
                product.Image = "" + ImageFile.FileName; // Lưu đường dẫn hình ảnh
            }

            bool isUpdated = Provider.Product.UpdateProduct(product); // Cập nhật sản phẩm
            if (isUpdated)
            {
                TempData["Message"] = "Product updated successfully!";
            }
            else
            {
                TempData["Error"] = "Failed to update the product.";
            }
            return RedirectToAction("Index"); // Quay về danh sách sản phẩm
        }

    }
