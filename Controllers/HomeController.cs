using armcoordination_dashboard.Data;
using armcoordination_dashboard.Models;
using armcoordination_dashboard.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace armcoordination_dashboard.Controllers
{
    public class HomeController : Controller
    {

        private readonly IHomeRepository _homeRepository;
        public HomeController(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult deleteChild(int id)
        {
            // TODO
            _homeRepository.deleteInfoChild(id);
            return RedirectToAction("MainPage");
        }

        public IActionResult newChild()
        {
            
            return View();
        }

        public IActionResult editChild(int id)
        {
            children _children = _homeRepository.getInfoChild(id);
            ChildModel child = new ChildModel();
            child.date_of_birth = _children.date_of_birth;
            child.id = _children.id;
            child.names = _children.names;
            child.last_name = _children.last_name;
            child.gender = _children.gender;
            return View(child);
        }

        [HttpPost]
        public IActionResult editChild(ChildModel childModel)
        {
            if (ModelState.IsValid && childModel.date_of_birth < DateTime.Now.Date)
            {
                _homeRepository.updateInfoChild(childModel);
                return RedirectToAction("MainPage");
                
            }

            if (childModel.date_of_birth > DateTime.Now.Date)
            {
                ModelState.AddModelError("", "Por favor, introduzca la fecha de nacimiento correcta");
            }


            return View(childModel);
        }


        [HttpPost]
        public IActionResult newChild(ChildModel childModel)
        {
            if (ModelState.IsValid && childModel.date_of_birth < DateTime.Now.Date) {
                int id = _homeRepository.addNewChild(childModel, User.Identity.Name);
                if (id > 0)
                {
                    return RedirectToAction("MainPage");
                }
            }

            if (childModel.date_of_birth > DateTime.Now.Date) {
                ModelState.AddModelError("", "Por favor, introduzca la fecha de nacimiento correcta");
            }

            
            return View(childModel);
        }

        public async Task<IActionResult> MainPage()
        {
            var data = await _homeRepository.getChildren(User.Identity.Name);
            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
