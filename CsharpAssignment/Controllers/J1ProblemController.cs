using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace C_Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J1ProblemController : ControllerBase
    {
        /// <summary>
        /// Calculates the total scores of two players and determines the winner.
        /// </summary>
        /// <param name="player1Level1">Player 1's achievements in Level 1.</param>
        /// <param name="player1Level2">Player 1's achievements in Level 2.</param>
        /// <param name="player1Level3">Player 1's achievements in Level 3.</param>
        /// <param name="player2Level1">Player 2's achievements in Level 1.</param>
        /// <param name="player2Level2">Player 2's achievements in Level 2.</param>
        /// <param name="player2Level3">Player 2's achievements in Level 3.</param>
        /// <returns>The result of the game: 'Player 1 Wins', 'Player 2 Wins', or 'Tie'.</returns>
        /// <example>
        /// POST: curl -H "Content-Type: application/x-www-form-urlencoded" -d "player1Level1=10&player1Level2=15&player1Level3=20&player2Level1=12&player2Level2=14&player2Level3=18" "https://localhost:7033/api/J1Problem/CalculateScores"
        /// </example>
        [HttpPost("CalculateScores")]
        [Consumes("application/x-www-form-urlencoded")]
        public string CalculateScores(
            [FromForm] int player1Level1,
            [FromForm] int player1Level2,
            [FromForm] int player1Level3,
            [FromForm] int player2Level1,
            [FromForm] int player2Level2,
            [FromForm] int player2Level3)
        {
            // Calculate total points for Player 1
            int player1TotalScore = player1Level1 + player1Level2 + player1Level3;

            // Calculate total points for Player 2
            int player2TotalScore = player2Level1 + player2Level2 + player2Level3;

            // Determine the result
            if (player1TotalScore > player2TotalScore)
            {
                return "Player 1 Wins";
            }
            else if (player2TotalScore > player1TotalScore)
            {
                return "Player 2 Wins";
            }
            else
            {
                return "Tie";
            }
        }
    }
}