using YoYoTestApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using YoYoTestApp.Shared.Models;
using YoYoTestApp.Server.Services;

namespace YoYoTestApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class YoYoTestController : ControllerBase
    {
        private readonly ILogger<YoYoTestController> logger;
        private readonly IYoYoService _yoyoservice;

        public YoYoTestController(ILogger<YoYoTestController> logger, IYoYoService yoyoService)
        {
            this.logger = logger;
            this._yoyoservice = yoyoService;
        }

        [HttpGet("GetTests")]
        public IActionResult GetTestData()
        {
            var _tests = _yoyoservice.LoadTests();
            return Ok(_tests);

        }

        [HttpGet("GetAthletes")]
        public IActionResult GetAthletes()
        {
            var _athletes = _yoyoservice.LoadAthletes();
            return Ok(_athletes);

        }

        [HttpPost("Warn")]
        public IActionResult Warn([FromBody] string Id)
        {
            int intId;
            if (Id.StringToDoubleThenInt(out intId))
            {

                _yoyoservice.Warn(intId);
                return Ok();
            }
            throw new Exception("Invalid request");
        }

        [HttpPost("Stop")]
        public IActionResult Stop([FromBody] string Id)
        {
            int intId;
            if (Id.StringToDoubleThenInt(out intId))
            {
                _yoyoservice.Stop(intId);
                return Ok();
            }
            throw new Exception("Invalid request");
        }

        [HttpPost("Updatecounter")]
        public IActionResult Updatecounter([FromQuery] double actualdistance)
        {
            _yoyoservice.UpdateCounter(actualdistance);
            return Ok();
        }

        [HttpGet("UpdateAthleteInfo")]
        public IActionResult UpdateAthleteInfo()
        {
            _yoyoservice.UpdateAthleteInfo();
            return Ok();
        }

        [HttpPost("Edit")]
        public IActionResult Edit([FromBody] dynamic userdata)
        {
            int id = userdata.id;
            int level = userdata.level;
            int shuttle = userdata.shuttle;
            _yoyoservice.OnEditButtonClick(id, level, shuttle);
            return Ok();
        }
    }
}
