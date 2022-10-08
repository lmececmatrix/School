using KinderGarten.Models;
using KinderGarten.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KinderGarten.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogRepository _blogRepository;

        public BlogController(BlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public IActionResult Create() { return View(); }

        public async Task<IActionResult> Create(BlogModel blog)
        {
            if (ModelState.IsValid)
            {
                var id = await _blogRepository.Create(blog);

                if (id > 0)
                    return RedirectToAction("Create");
                
            }

            return View();
        }

        public async Task<IActionResult> All()
        {
            return View(await _blogRepository.GetAllBlogs());
        }
    }
}
