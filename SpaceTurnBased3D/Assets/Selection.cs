using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Selection : ScriptableObject {

    public Ship Ship;
    public Vector3[] CurvePoints = new Vector3[3];
}
