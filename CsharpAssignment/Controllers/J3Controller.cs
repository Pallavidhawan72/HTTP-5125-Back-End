using Microsoft.AspNetCore.Mvc;

namespace AdventureGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J3Controller: ControllerBase
    {
        /// <summary>
        /// Finds the length of the longest sequence of consecutive identical characters in a given text.
        /// </summary>
        /// <param name="text">The text passed as a query parameter.</param>
        /// <returns>The length of the longest sequence of consecutive identical characters.</returns>
        /// <example>
        /// GET: curl "https://localhost:7033/api/J3Controller/FindLongestSequence?text=aaabbccccd"
        /// -> 4
        /// </example>
        [HttpGet("FindLongestSequence")]
        public int FindLongestSequence([FromQuery] string text)
        {
            if (string.IsNullOrEmpty(text))
                return 0;

            int maxLength = 1;
            int currentLength = 1;

            for (int i = 1; i < text.Length; i++)
            {
                if (text[i] == text[i - 1])
                {
                    currentLength++;
                    if (currentLength > maxLength)
                        maxLength = currentLength;
                }
                else
                {
                    currentLength = 1;
                }
            }

            return maxLength;
        }
    }
}
