using KinderGarten.Models;
using KinderGarten.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KinderGarten.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeacherController : Controller
    {
        private readonly TeacherRepository _teacherRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TeacherController(TeacherRepository teacherRepository, IWebHostEnvironment webHostEnvironment)
        {
            _teacherRepository = teacherRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<ViewResult> All()
        {
            return View(await _teacherRepository.GetAllTeachers());
        }

        [HttpGet]
        public IActionResult Create() { return View(); }
        [HttpPost]
        public async Task<IActionResult> Create(TeacherModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Image != null)
                {
                    string folder = "images" + "/" + 
                                    Guid.NewGuid().ToString() + model.Image.FileName;
                    string fullName = 
                        Path.Combine(_webHostEnvironment.WebRootPath, folder);

                    model.ImageUrl = "/" + folder;

                    await model.Image.CopyToAsync(new FileStream(fullName, FileMode.Create));
                }

                
                var id = await _teacherRepository.Create(model);

                if (id > 0)
                {
                    return RedirectToAction("Create");
                }
                
            }

            return View();
        }
    }
}
