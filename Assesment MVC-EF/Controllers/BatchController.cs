using Assesment_MVC_EF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assesment_MVC_EF.Controllers
{
    public class BatchController : Controller
    {

        BatchInterface _repo;
        CourseInterface _repo1;
        public BatchController(BatchInterface repo, CourseInterface repo1)
        {
            _repo = repo;
            _repo1 = repo1;

        }



        public IActionResult Index()
        {
            return View(_repo.GetBatches());
        }
        public IActionResult Details(int id)
        {
            return View(_repo.GetBatchById(id));
        }
        



        public IActionResult Create()
        {
            ViewData["Courses"] =
                new SelectList(_repo1.GetCourses(),
                    "CourseId", "CourseName"
 );
            return View();
        }
        [HttpPost]
        public IActionResult Create(Batch batch)
        {
            _repo.Create(batch);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            ViewData["Courses"] =
    new SelectList(_repo1.GetCourses(),
        "CourseId", "CourseName"
);
            Batch obj2 = _repo.GetBatchById(id);
            return View(obj2);
        }
        [HttpPost]
        public IActionResult Edit(int id, Batch batch)
        {
            _repo.Edit(id, batch);
            return RedirectToAction("index");
        }
    }
}

