using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curve : MonoBehaviour {

    public LineRenderer lineRenderer;
    public Selection Selection;

    public static int activePoint = 0;
    public static float radius = 1;

    public static int numPoints = 50;
    public static Vector3[] positions = new Vector3[50];

    private void Start()
    {
        lineRenderer.positionCount = numPoints;
    }

    private void Update()
    {
        if (Selection.Ship != null)
        {
            CalculateQuadraticCurve();
            DrawQuadraticCurve();
        }
    }

    private void DrawQuadraticCurve()
    {
        lineRenderer.SetPositions(positions);
    }

    private void CalculateQuadraticCurve()
    {
        for (int i = 1; i < numPoints + 1; ++i)
        {
            float t = i / (float)numPoints;
            positions[i - 1] = CalculateQuadraticBezierPoint(t, Selection.Ship.ChosenCurvePoints[0], Selection.Ship.ChosenCurvePoints[1], Selection.Ship.ChosenCurvePoints[2]);
        }
    }

    private static void CalculateQuadraticCurve(Ship ship)
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

    public static void MoveShip(Ship ship)
    {
        activePoint = 0;
        CalculateQuadraticCurve(ship);
    }
    public static IEnumerator Move(Ship ship)
    {
        while (ship.activeWaypoint < 50)
        {
            ship.transform.position = Vector3.MoveTowards(ship.transform.position, ship.curveWaypoints[ship.activeWaypoint], Time.deltaTime * 25);
            if (ship.activeWaypoint + 5 < ship.curveWaypoints.Length)
            {
                var rotation = Quaternion.LookRotation(positions[ship.activeWaypoint + 5] - ship.transform.position);
                ship.transform.rotation = Quaternion.Slerp(ship.transform.rotation, rotation, Time.deltaTime * 15);
            }


            if (Vector3.Distance(ship.curveWaypoints[ship.activeWaypoint], ship.transform.position) < radius)
            {
                ++ship.activeWaypoint;
            }

            yield return null;
        }
        ship.activeWaypoint = 0;
    }
}

/*
    public static void MoveShip(Ship ship)
    {
        activePoint = 0;
        CalculateQuadraticCurve(ship.ChosenCurvePoints);

        int i = 0;
        while (i < 50)
        {
            ship.transform.position = Vector3.MoveTowards(ship.transform.position, positions[i], Time.deltaTime * 5);
            if (i + 5 < positions.Length)
            {
                var rotation = Quaternion.LookRotation(positions[i + 5] - ship.transform.position);
                ship.transform.rotation = Quaternion.Slerp(ship.transform.rotation, rotation, Time.deltaTime * 5);
            }


            if (Vector3.Distance(positions[i], ship.transform.position) < radius)
            {
                i++;
            }
            if (activePoint == positions.Length)
            {
                return;
            }
        }
    }

    IEnumerator Move()
    {
        for (float f = 1f; f >= 0; f -= 0.1f)
        {

            yield return null;
        }
    }
 */
