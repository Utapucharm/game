using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class CoolMath
{
    
    public static Vector2 CalculateCirclePoint(float radius, int angle)
    {
        return new Vector2(radius * Mathf.Sin(angle * Mathf.Deg2Rad), radius * Mathf.Cos(angle * Mathf.Deg2Rad)); 
    }
}
