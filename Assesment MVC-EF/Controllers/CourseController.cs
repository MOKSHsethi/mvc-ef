using Assesment_MVC_EF.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assesment_MVC_EF.Controllers
{
    public class CourseController : Controller
    {

        CourseInterface _repo;
        public CourseController(CourseInterface repo)
        {
            _repo = repo;
        }



        public IActionResult Index()
        {
            return View(_repo.GetCourses());
        }
        public IActionResult Details(int id)
        {
            return View(_repo.GetCourseById(id));
        }
        public IActionResult Delete(int id)
        {
            Course obj = _repo.GetCourseById(id);
            return View(obj);
        }



        [HttpPost]
        public IActionResult Deleted(int CourseId)
        {
            _repo.Delete(CourseId);
            return RedirectToAction("index");
        }



        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Course course)
        {

            var t = _repo.GetCourses();
            _repo.Create(course);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            Course obj2 = _repo.GetCourseById(id);
            return View(obj2);
        }
        [HttpPost]
        public IActionResult Edit(int id, Course course)
        {
            _repo.Edit(id, course);
            return RedirectToAction("index");
        }
    }
}
    
