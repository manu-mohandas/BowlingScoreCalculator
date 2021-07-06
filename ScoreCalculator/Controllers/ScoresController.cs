using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScoreCalculator.Model;
using ScoreCalculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private readonly IBowlingScoreServices _bowlingScoreServices;
        public ScoresController(IBowlingScoreServices bowlingScoreServices)
        {
            _bowlingScoreServices = bowlingScoreServices;
        }

        [HttpPost]
        public ActionResult<BowlingScoreResult> Get([FromBody] BowlingScoreRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_bowlingScoreServices.GetFrameProgressScores(request.PinsDowned));
        }
    }
}
