using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveCalculator : MonoBehaviour {

    public const int numPoints = 50;
    //public Vector3[] positions = new Vector3[50];

    public static void CalculateQuadraticCurve(Ship ship)
    {
        for (int i = 1; i < numPoints + 1; ++i)
        {
            float t = i / (float)numPoints;
            ship.curveWaypoints[i - 1] = CalculateQuadraticBezierPoint(t, ship.ChosenCurvePoints[0], ship.ChosenCurvePoints[1], ship.ChosenCurvePoints[2]);
        }
    }

    private static Vector3 CalculateQuadraticBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        //B(t) = (1-t)^2*P0 + 2(1-t)tP1 + t^2*P2
        return (1 - t) * (1 - t) * p0 + 2 * (1 - t) * t * p1 + t * t * p2;
    }
}
