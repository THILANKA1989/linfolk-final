using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication9.Models;
using Microsoft.Extensions.Logging;
using System.Net;
using AutoMapper;
using WebApplication9.ViewModels;
using WebApplication9.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication9.Controllers.Api
{
    [Route("api/trips/{tripName}/stops")]
    public class StopController : Controller
    {
        private ILogger _logger;
        private IPortRepository _repository;
        private CoordService _coordService;

        public StopController(IPortRepository repository, ILogger<StopController> logger, CoordService coordService)
        {
            _logger = logger;
            _repository = repository;
            _coordService = coordService;
        }

        [HttpGet("")]
        public JsonResult Get(string tripName)
        {
            try
            {
                var results = _repository.GetTripByName(tripName);
                if (results == null)
                {
                    return Json(null);
                }
                return Json(Mapper.Map<IEnumerable<StopViewModel>>(results.Stops));
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get stops",ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Error");
            }
        }

        [HttpPost("")]
        public async Task<JsonResult> Post(string tripName, [FromBody]StopViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Map top Entity
                    var newStop = Mapper.Map<Stop>(vm);

                    //LookingUp Coordinates
                    var coordResult = await _coordService.Lookup(newStop.Name);
                    if (!coordResult.Success)
                    {
                        Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        Json(coordResult.Message);
                    }

                    newStop.Longitude = coordResult.Longitude;
                    newStop.Latitude = coordResult.Latitude;

                    //save to database
                    _repository.AddStop(tripName,newStop);
                    if (_repository.SaveAll())
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return Json(Mapper.Map<StopViewModel>(newStop));
                    }
                }
                return Json(null);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to add new stop", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.ToString());
            }
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
