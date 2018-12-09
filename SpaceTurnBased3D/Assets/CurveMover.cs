using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveMover : MonoBehaviour {

    public int activePoint = 0;
    public float radius = 1;

    public void MoveShip(Ship ship)
    {
        activePoint = 0;
        CurveCalculator.CalculateQuadraticCurve(ship);
        StartCoroutine(Move(ship));
    }

    public IEnumerator Move(Ship ship)
    {
        while (ship.activeWaypoint < 50)
        {
            ship.transform.position = Vector3.MoveTowards(ship.transform.position, ship.curveWaypoints[ship.activeWaypoint], Time.deltaTime * 25);
            if (ship.activeWaypoint + 5 < ship.curveWaypoints.Length)
            {
                var rotation = Quaternion.LookRotation(ship.curveWaypoints[ship.activeWaypoint + 5] - ship.transform.position);
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
