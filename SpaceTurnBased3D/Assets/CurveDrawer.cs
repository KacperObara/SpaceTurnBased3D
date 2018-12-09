using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveDrawer : MonoBehaviour {

    public const int numPoints = 50;
    //public Vector3[] positions = new Vector3[50];

    public LineRenderer LineRenderer;
    public Selection Selection;

    //public static bool Drawing = false;

    private void Start()
    {
        LineRenderer.positionCount = numPoints;
    }

    private void Update()
    {
        if (Selection.Ship != null) //Drawing == true && 
        {
            CurveCalculator.CalculateQuadraticCurve(Selection.Ship);
            //positions = Selection.Ship.curveWaypoints;
            DrawQuadraticCurve();
        }

        //if (Selection.Ship != null && Input.GetKeyDown(KeyCode.A))
        //{
        //    positions = Selection.Ship.curveWaypoints;
        //}
    }

    public void DrawQuadraticCurve()
    {
        LineRenderer.SetPositions(Selection.Ship.curveWaypoints);
    }

    //public static void EnableDrawing(Vector3[] newPositions)
    //{
    //    Drawing = true;
    //    positions = newPositions;
    //}
}
