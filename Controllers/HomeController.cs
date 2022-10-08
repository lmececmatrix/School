using KinderGarten.Data;
using KinderGarten.Models;
using KinderGarten.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KinderGarten.Controllers
{ 
    public class HomeController : Controller
    {
        private BookRepository _bookRepository;
        private ClassRepository _classRepository;
        private TeacherRepository _teacherRepository;

        public HomeController(BookRepository bookRepository, 
                              ClassRepository classRepository,
                              TeacherRepository teacherRepository)
        {
            _bookRepository = bookRepository;
            _classRepository = classRepository;
            _teacherRepository = teacherRepository;
        }


        public async Task<ViewResult> Index() 
        {
            ViewBag.Team = (await _teacherRepository.GetAllTeachers()).Take(4);

            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> Index(BookModel book)
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.Create(book);

                if (id > 0)
                    return RedirectToAction("Index");
                
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AboutUs(int id, string name)  
        { 
            return View(await _teacherRepository.GetAllTeachers()); 
        }
        public ViewResult ContactUs() { return View(); }
        public ViewResult Gallery() { return View(); }
        public ViewResult Blog() { return View(); }
        public async Task<ViewResult> Team() 
        { 
            return View(await _teacherRepository.GetAllTeachers()); 
        }

        [HttpGet]
        public async Task<ViewResult> Class() 
        {
            var data = await _classRepository.GetAllClasses();

            ViewBag.LClasses = new SelectList(data, "Id", "Name");
            ViewBag.Classes = data;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Class(BookModel model)
        {
            if (ModelState.IsValid)
            {
                var id = await _bookRepository.Create(model);

                if (id > 0)
                    return RedirectToAction("Class");
            }

            var data = await _classRepository.GetAllClasses();

            ViewBag.LClasses = new SelectList(data, "Id", "Name");
            ViewBag.Classes = data;

            return View();
        }


        public async Task<ViewResult> Single(int id) 
        {
            var @class = await _classRepository.GetClassById(id);

            return View(@class);
        }
        
    }
}
