using Microsoft.AspNetCore.Mvc;

namespace AdventureGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J2ProblemController: ControllerBase
    {
        /// <summary>
        /// Calculates Gorla's final energy after encountering Zunis.
        /// </summary>
        /// <param name="startingEnergy">Gorla's initial energy level.</param>
        /// <param name="zuniEnergies">A comma-separated list of Zuni energy levels.</param>
        /// <returns>The final energy level of Gorla after encounters.</returns>
        /// <example>
        /// POST: curl -X POST "https://localhost:7033/api/J2Problem/ComputeFinalEnergy" -H "Content-Type: application/x-www-form-urlencoded" -d "startingEnergy=50&zuniEnergies=30,20,60,10"
        /// -> 110
        /// curl -X POST "https://localhost:7033/api/J2PRoblem/ComputeFinalEnergy" -H "Content-Type: application/x-www-form-urlencoded" -d "startingEnergy=100&zuniEnergies=90,110,50"
        /// -> 190
        /// </example>
        [HttpPost("ComputeFinalEnergy")]
        [Consumes("application/x-www-form-urlencoded")]
        public IActionResult ComputeFinalEnergy([FromForm] int startingEnergy, [FromForm] string zuniEnergies)
        {
            int gorlaEnergy = startingEnergy;

            // Split the comma-separated Zuni energy levels
            string[] zuniArray = zuniEnergies.Split(',');

            // Iterate through the Zuni energy levels
            foreach (var zuni in zuniArray)
            {
                if (int.TryParse(zuni, out int zuniEnergy))
                {
                    // Gorla absorbs the Zuni if its energy is less, or stops if it's equal or greater
                    if (zuniEnergy < gorlaEnergy)
                    {
                        gorlaEnergy += zuniEnergy;
                    }
                    else
                    {
                        break; // Gorla stops when encountering a Zuni with equal or greater energy
                    }
                }
                else
                {
                    return BadRequest("Invalid input"); // Return error if Zuni energy isn't a valid integer
                }
            }

            // Return Gorla's final energy level
            return Ok(gorlaEnergy);
        }
    }
}
