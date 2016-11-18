using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication9.Models;
using WebApplication9.ViewModels;
using Microsoft.Extensions.Logging;
using AutoMapper;
using System.Net;
using WebApplication9.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication9.Controllers.AuthorApi
{
    [Route("api/authors")]
    public class AuthorController : Controller
    {
        private ILogger<AuthorController> _logger;
        private IPortRepository _repository;

        public AuthorController(IPortRepository repository, ILogger<AuthorController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("")]
        public JsonResult Get()
        {
            var results = Mapper.Map<IEnumerable<AuthorViewModel>>(_repository.GetAuthorList());
            return Json(results);

        }

        [HttpPost("")]
        public JsonResult Post([FromBody]AuthorViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newPost = Mapper.Map<WebApplication9.Models.Author>(vm);
                    _logger.LogInformation("Attemppting to save new post");
                    _repository.AddAuthor(newPost);

                    if (_repository.SaveAll())
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return Json(new { Message = "Saved Successfully", ModelState = ModelState });
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to Save new post", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message, ModelState = ModelState });
            }
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { Message = "Failed", ModelState = ModelState });
        }
    }
}
