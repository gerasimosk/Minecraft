using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Side2 : MonoBehaviour {
    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(-0.8f,0, (float) MainMenu.size);
        transform.rotation = Quaternion.Euler(90,90,0);
        transform.localScale = new Vector3(MainMenu.size / 2,1, MainMenu.size / 2);
    }
}
