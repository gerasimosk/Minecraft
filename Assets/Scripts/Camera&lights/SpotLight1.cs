using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLight1 : MonoBehaviour
{
    Light lt;
    // Use this for initialization
    void Start()
    {
        lt = GetComponent<Light>();
        lt.type = LightType.Spot;
        transform.position = new Vector3(0, (float) MainMenu.size, 0);
        transform.rotation = Quaternion.Euler(60, 40, 0);
        lt.range = 2 * MainMenu.size;
        lt.spotAngle = 80;
        lt.intensity = 5;
    }
}
