using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Side1 : MonoBehaviour {
    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(MainMenu.size - 0.2f,0, MainMenu.size - 0.8f);
        transform.rotation = Quaternion.Euler(90,90,180);
        transform.localScale = new Vector3(MainMenu.size / 2,1, MainMenu.size / 2);
    }
}
