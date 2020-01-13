using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    float intensity;
    Color tileColor;


    // Start is called before the first frame update
    void Start()
    {
        tileColor = new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CalculateColor();
        GetComponent<Renderer>().material.color = tileColor;
    }

    private void FixedUpdate()
    {
        intensity = 0;
    }

    void CalculateColor()
    {

        if(intensity < 0)
        {
            tileColor = new Color(1, 1/(intensity*(-1)), 1/(intensity * (-1)), 0);
        }
        else
        {
            tileColor = new Color(1/intensity, 1/intensity, 1, 0);
        }
    }

    public void ApplyIntensity(float distance)
    {
        intensity += distance;
    }
}

