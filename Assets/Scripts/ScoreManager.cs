using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    private const int WINNING_SCORE = 50;

    /// <summary>
    /// Game start message: Prompts the player to collect coins to win the game.
    /// </summary>
    void Start()
    {
        Debug.Log($" Collect coins to increase your Score.\n Reach {WINNING_SCORE} to win.\n Score: {score}");
    }

    /// <summary>
    /// Adds the value of the coin collected to the current score and displays updated score to the player.
    /// Displays winning message should the player reach the winning score.
    /// </summary>
    /// <param name="pointValue">
    /// the amount to increase the current score by, passed in by coins when they're collected.
    /// </param>
    public void IncreaseScore(int pointValue)
    {
        if (score < WINNING_SCORE)
        {
            score += pointValue;
            Debug.Log($"Coin collected! Your Score is now: {score}!");
        }
        else
        {
            Debug.Log("Congratulations! You've won!");
        }
    }
}
