using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    float intensity, lastIntensity;
    Color tileColor;


    // Start is called before the first frame update
    void Start()
    {
        intensity = 0;
        lastIntensity = 0;
        tileColor = new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CalculateColor();
        GetComponent<Renderer>().material.color = tileColor;
        lastIntensity = intensity;
    }

    void FixedUpdate()
    {
        intensity = 0;
    }

    void CalculateColor()
    {
        if(intensity == 0)
        {
            intensity = 0.1f;
        }
        if(intensity < 0)
        {
            tileColor = new Color(1, 1/(intensity*(-1)), 1/(intensity * (-1)), 0);
        }
        else
        {
            tileColor = new Color(1/intensity, 1/intensity, 1, 0);
        }
    }

    public void ApplyIntensity(float distance, bool negative)
    {
        float intensityToApply;
        if (distance < 1) intensityToApply = 10;
        else if (distance < 1.5f) intensityToApply = 4;
        else if (distance < 2.5f) intensityToApply = 0.5f;
        else intensityToApply = 0;

        if (negative) intensity -= intensityToApply;
        else intensity += intensityToApply;
    }

    public float GetLastIntensity()
    {
        return lastIntensity;
    }
}

