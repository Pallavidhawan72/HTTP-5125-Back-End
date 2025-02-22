using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace C_Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J2Controller : ControllerBase
    {
        /// <summary>
        /// Calculates total spiciness based on ingredients.
        /// </summary>
        /// <param name="Ingredients">Comma-separated list of pepper names</param>
        /// <returns>Total SHU score</returns>
        [HttpGet("ChiliPeppers")]
        public string ChilliPepper([FromQuery] string Ingredients)
        {
            int totalShu = 0;
            string[] pepperArray = Ingredients.Split(',');
            
            foreach (var pepper in pepperArray)
            {
                // Add SHU based on the pepper name
                if (pepper == "Poblano")
                {
                    totalShu += 1500;
                }
                else if (pepper == "Mirasol")
                {
                    totalShu += 6000;
                }
                else if (pepper == "Serrano")
                {
                    totalShu += 15500;
                }
                else if (pepper == "Cayenne")
                {
                    totalShu += 40000;
                }
                else if (pepper == "Thai")
                {
                    totalShu += 75000;
                }
                else if (pepper == "Habanero")
                {
                    totalShu += 125000;
                }
                else
                {
                    return "Invalid input"; // If any pepper is invalid, return an error message
                }
            }

            return totalShu.ToString(); // Return the total SHU as a string
        }
    }
}

