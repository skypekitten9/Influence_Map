using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentScript : MonoBehaviour
{
    GameObject tileMap;
    public float visionRange;
    public float speed;
    private Vector3 target;

    // Update is called once per frame
    void Update()
    {
        Vector3 positionToMoveTowards = transform.position;
        float smallestIntensity = 30;
        tileMap = GameObject.Find("Tilemap");
        foreach (Transform child in tileMap.transform)
        {
            float distance = Vector3.Distance(child.transform.position, transform.position);
            if (distance <= visionRange && smallestIntensity > child.GetComponent<TileScript>().GetLastIntensity())
            {
                smallestIntensity = child.GetComponent<TileScript>().GetLastIntensity();
                positionToMoveTowards.x = child.transform.position.x;
                positionToMoveTowards.z = child.transform.position.z;
                Debug.Log("entered if");
            }
        }
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, positionToMoveTowards, step);
        Debug.Log("Moved agent to " + positionToMoveTowards.x + " " + positionToMoveTowards.z);
    }
}
