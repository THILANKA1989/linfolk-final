using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication9.ViewModels;
using WebApplication9.Services;
using WebApplication9.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication9.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;
        private IPortRepository _repository;
        public AppController(IMailService service, IPortRepository repository)
        {
            _mailService = service;
            _repository = repository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var trips = _repository.GetAllTrips();
            return View(trips);
        }

        public IActionResult Trips()
        {
            var trips = _repository.GetAllTrips();
            return View(trips);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            _mailService.SendMail("thilankaranasinghe1989@gmail.com","thilankaranasinghe1989@gmail.com",model.Message,model.Name);
            return View();
        }


        public IActionResult Project()
        {
            return View();
        }
    }
}
