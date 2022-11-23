using UnityEngine;

public static class AwesomeMath
{
    public static Vector2 CalculateCircleCoordinate(float radius, float angle)
    {
        return new Vector2(radius * Mathf.Cos(angle * Mathf.Deg2Rad), radius * Mathf.Sin(angle * Mathf.Deg2Rad));
    }
}
