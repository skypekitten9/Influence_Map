using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffectMapScript : MonoBehaviour
{
    GameObject tileMap;
    public bool negative;

    // Update is called once per frame
    void Update()
    {
        tileMap = GameObject.Find("Tilemap");
        foreach(Transform child in tileMap.transform)
        {
            float distance = Vector3.Distance(child.transform.position, transform.position);
            child.GetComponent <TileScript>().ApplyIntensity(distance, negative);
        }

    }
}
