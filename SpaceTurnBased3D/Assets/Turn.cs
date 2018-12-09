using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour {

    public Entities Entities;
    public int i = 0;

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(1))
        {
            for (i = 0; i < Entities.Ships.Count; ++i)
            {
                //MoveShip(Entities.Ships[i]);
                Entities.Ships[i].GetComponent<CurveMover>().MoveShip(Entities.Ships[i]);
                StartCoroutine(Curve.Move(Entities.Ships[i]));
            }
        }

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    CurveDrawer.EnableDrawing();
        //}
    }
}
