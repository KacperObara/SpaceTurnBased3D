using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour {

    Camera cam;

	// Use this for initialization
	void Start () {
        cam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Ship")
                {
                    Debug.Log("Clicked on: " + hit.transform.name);
                }
            }
            else
            {
                Debug.Log("Nothing");
            }
        }
    }
}
