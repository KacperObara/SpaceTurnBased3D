using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curve : MonoBehaviour {

    public LineRenderer lineRenderer;
    public List<Transform> points;

    ///
    public Transform ship;
    public bool moving = false;
    public int activePoint = 0;
    public float radius = 1;
    public float speed = 5f;
    ///
    public int numPoints = 50;
    public Vector3[] positions = new Vector3[50];

    private void Start()
    {
        lineRenderer.positionCount = numPoints;
       
    }

    private void Update()
    {
        DrawQuadraticCurve();
        if (Input.GetKeyDown(KeyCode.Alpha1) && moving == false)
        {
            moving = true;
        }

        if (moving == true)
        {
            ship.transform.position = Vector3.MoveTowards(ship.transform.position, positions[activePoint], Time.deltaTime * speed);
            if (activePoint + 5 < positions.Length)
            {
                var rotation = Quaternion.LookRotation(positions[activePoint + 5] - ship.transform.position);
                ship.transform.rotation = Quaternion.Slerp(ship.transform.rotation, rotation, Time.deltaTime * 5);
            }
            

            if (Vector3.Distance(positions[activePoint], ship.transform.position) < radius)
            {
                activePoint++;
            }
            if (activePoint == positions.Length)
            {
                moving = false;
                //var rotation = Quaternion.LookRotation(positions[49] - positions[48]);
                //ship.transform.rotation = Quaternion.Slerp(ship.transform.rotation, rotation, Time.deltaTime * 5);
            }
        }
    }

    private void DrawQuadraticCurve()
    {
        for (int i = 1; i < numPoints + 1; ++i)
        {
            float t = i / (float)numPoints;
            positions[i - 1] = CalculateQuadraticBezierPoint(t, points[0].position, points[1].position, points[2].position);
        }
        lineRenderer.SetPositions(positions);
    }

    private Vector3 CalculateQuadraticBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        //B(t) = (1-t)^2*P0 + 2(1-t)tP1 + t^2*P2
        return (1 - t) * (1 - t) * p0 + 2 * (1 - t) * t * p1 + t * t * p2;
    }

}
