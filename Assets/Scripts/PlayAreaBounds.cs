using UnityEngine;

public static class PlayAreaBounds
{
    private static float NorthBound = 50f;
    private static float SouthBound = -50f;
    private static float EastBound = 50f;
    private static float WestBound = -50f;
    private static float randomXInPlayArea;
    private static float randomZInPlayArea;

    public static Vector3 RandomLocationInPlayArea()
    {
        randomXInPlayArea = Random.Range(PlayAreaBounds.WestBound, PlayAreaBounds.EastBound);
        randomZInPlayArea = Random.Range(PlayAreaBounds.SouthBound, PlayAreaBounds.NorthBound);
        return new Vector3(randomXInPlayArea, 0, randomZInPlayArea);
    }
}
