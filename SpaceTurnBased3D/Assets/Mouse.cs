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
                    Selection.Ship.ChosenCurvePoints[0] = Selection.Ship.transform.position;
                    Selection.Ship.ChosenCurvePoints[1] = Selection.Ship.transform.Find("Collider").transform.position;
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
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "CurveSpace" && hit.transform.parent == Selection.Ship.transform)
                {
                    Selection.Ship.ChosenCurvePoints[2] = hit.point;
                    defaultY = hit.point.y;
                }
            }


            Selection.Ship.ChosenCurvePoints[2].y = defaultY + offsetY;
        }
    }
}
