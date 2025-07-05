using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PORTFOLIO.Data;
using PORTFOLIO.Models;


namespace PORTFOLIO.Controllers
{
    public class HomeController : Controller
    {


        readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
            
        }
        [HttpGet]
        public async Task< IActionResult> Project()
        {
            var a = await _context.Projects.ToListAsync();
             return View(a);
        
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(PORTFOLIO.Models.Port  model)
        {
            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                string wwwRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                Directory.CreateDirectory(wwwRootPath); 

                string fileName = Path.GetFileName(model.ImageFile.FileName);
                string fullPath = Path.Combine(wwwRootPath, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(stream);
                }

                model.ImagePath = "/images/" + fileName;

              
                _context.Projects.Add(model);
                _context.SaveChanges();

                TempData["Success"] = "Project uploaded!";
                return RedirectToAction("Project");
            }

            TempData["Error"] = "Please choose an image.";
            return View(model);
        }
        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

    }
}
