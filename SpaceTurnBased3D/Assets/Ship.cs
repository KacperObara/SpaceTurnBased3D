using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Entities entities;

    public Vector3[] curveWaypoints = new Vector3[50];
    public int activeWaypoint = 0;
    public Vector3[] ChosenCurvePoints = new Vector3[3];

    private void Start()
    {
        entities.Ships.Add(this);
    }
}
