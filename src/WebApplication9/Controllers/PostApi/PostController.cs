using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication9.Models;
using Microsoft.Extensions.Logging;
using AutoMapper;
using System.Net;
using WebApplication9.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication9.Controllers.PostApi
{
    [Route("api/posts")]
    public class PostController : Controller
    {
        private ILogger<PostController> _logger;
        private IPortRepository _repository;

        public PostController(IPortRepository repository, ILogger<PostController> logger)
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
            var results = Mapper.Map<IEnumerable<PostViewModel>>(_repository.GetAllPosts());
            return Json(results);

        }

        [HttpPost("")]
        public JsonResult Post([FromBody]PostViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newPost = Mapper.Map<WebApplication9.Models.Post>(vm);
                    _logger.LogInformation("Attemppting to save new post");
                    _repository.AddPost(newPost);

                    if (_repository.SaveAll())
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return Json(Mapper.Map<PostViewModel>(newPost));
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
