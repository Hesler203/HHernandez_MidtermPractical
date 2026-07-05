using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;

    public void IncreaseScore(int pointValue)
    {
        score += pointValue;
    }
}
