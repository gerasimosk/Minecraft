using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLight2 : MonoBehaviour
{
    Light lt;
    // Use this for initialization
    void Start()
    {
        lt = GetComponent<Light>();
        lt.type = LightType.Spot;
        transform.position = new Vector3((float)MainMenu.size, (float)MainMenu.size, (float)MainMenu.size);
        transform.rotation = Quaternion.Euler(60, 225, 0);
        lt.range = 2* MainMenu.size;
        lt.spotAngle = 80;
        lt.intensity = 5;
    }
}
