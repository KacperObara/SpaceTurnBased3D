using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour {

    Camera cam;
    public Selection Selection;

    public float offsetY;
    public float defaultY;

	// Use this for initialization
	void Start () {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Selection.Ship != null)
        //{
        //    mouseOffset = Input.mousePosition - mouseStartPos;
        //    mouseOffset = new Vector3(mouseOffset.x, 0, mouseOffset.y);
        //}
        offsetY += Input.GetAxis("Mouse ScrollWheel") * 3;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Ship")
                {
                    Debug.Log("Clicked on: " + hit.transform.name);
                    Selection.Ship = hit.transform.GetComponent<Ship>();
                    Selection.CurvePoints[0] = Selection.Ship.transform.position;
                    Selection.CurvePoints[1] = Selection.Ship.transform.forward * 25;
                }
                else
                {
                    Selection.Ship = null;
                }
            }
            else
            {
                Debug.Log("Nothing");
                Selection.Ship = null;
            }
        }


        if (Selection.Ship != null)
        {
            //Selection.CurvePoints[2] = mouseOffset;
           

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "CurveSpace")
                {
                    Selection.CurvePoints[2] = hit.point;
                    defaultY = hit.point.y;
                }
            }
        }

        Selection.CurvePoints[2].y = defaultY + offsetY;
    }
}
