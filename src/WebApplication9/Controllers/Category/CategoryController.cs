using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication9.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication8.Controllers.Category
{
    public class CategoryController : Controller
    {
        private IPortRepository _repository;

        public CategoryController(IPortRepository repository)
        {
            _repository = repository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var cateogires = _repository.GetCategories();
            return View(cateogires);
        }
        
    }
}
