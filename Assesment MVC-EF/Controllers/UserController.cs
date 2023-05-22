using Assesment_MVC_EF.Context;
using Assesment_MVC_EF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Assesment_MVC_EF.Controllers
{
    public class UserController : Controller
    {

        UserInterface _repo;
        public UserController(UserInterface repo)
        {
            _repo = repo;


        }


        public IActionResult Index()
        {
            return View( _repo.GetUsers());
        }




        public IActionResult Create()
        {

            ViewBag.Roles = new SelectList(Enum.GetValues(typeof(Role)));
           

            
           
            return View();

        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            var t = _repo.GetUsers();

            _repo.Create(user);
            return RedirectToAction("Index");
        }


        public IActionResult Details(int id)
        {
            User obj = _repo.GetUserById(id);
            return View(obj);


        }
        public IActionResult Delete(int id)
        {
            User obj = _repo.GetUserById(id);
            return View(obj);
        }
        [HttpPost]
        public IActionResult Deleted(int UserID)
        {
            _repo.Delete(UserID);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            User obj = _repo.GetUserById(id);
            //if(obj!=null)

            return View(obj);

        }
        [HttpPost]
        public IActionResult Edit(int id, User user)
        {
            _repo.Edit(id, user);
            return RedirectToAction("Index");
        }
    }
}
        

