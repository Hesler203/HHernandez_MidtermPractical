using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    private const int WINNING_SCORE = 50;

    void Start()
    {
        Debug.Log($" Collect coins to increase your Score.\n Reach {WINNING_SCORE} to win.\n Score: {score}");
    }

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
