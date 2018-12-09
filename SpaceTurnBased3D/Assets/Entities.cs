using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Entities : ScriptableObject {

    public List<Ship> Ships;

    private void OnEnable()
    {
        Ships.Clear();
        //GameObject[] allShips = GameObject.FindGameObjectsWithTag("Ship");
        //foreach(GameObject ship in allShips)
        //{
        //    Ships.Add(ship.GetComponent<Ship>());
        //}
    }
}
