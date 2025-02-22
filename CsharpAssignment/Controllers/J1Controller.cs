using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace C_Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J1Controller : ControllerBase
    {
        /// <summary>
        /// Calculating the final score in Deliv-e-droid game.
        /// </summary>
        /// <param name = "collisions">Number of collison with obstacles</param>
        /// <param name = "deliveries">Number of packages delivered</param>
        /// <returns>Final score</returns>
        [HttpPost("Delivedroid")]
        [Consumes("application/x-www-form-urlencoded")]
        public IActionResult CalculateScore([FromForm] int deliveries, [FromForm] int collisions)
        {
            int score = (deliveries * 50) - (collisions * 10);
            if (deliveries > collisions)
            {
                score=score+ 500;
            }
            return Ok(score);
        }
    }
}
