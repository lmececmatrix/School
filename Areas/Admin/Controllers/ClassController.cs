using KinderGarten.Data;
using KinderGarten.Models;
using KinderGarten.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KinderGarten.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ClassController : Controller
    {
        private readonly ClassRepository _classRepository;

        public ClassController(ClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public IActionResult Index() { return View(); }

        [HttpGet]
        public IActionResult Create() { return View(); }
        [HttpPost]
        public async Task<IActionResult> Create(ClassModel @class)
        {
            if (ModelState.IsValid)
            {
                var id = await _classRepository.Create(@class);

                if (id > 0)
                {
                    return RedirectToAction("Create");
                }
            }

            return View(@class);
        }

        public async Task<IActionResult> All() 
        { 
            return View(await _classRepository.GetAllClasses());  
        }
    }
}
