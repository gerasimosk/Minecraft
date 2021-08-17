using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour {
	void Start () {
        transform.position = new Vector3((int)Mathf.Round(MainMenu.size / 2), 2, (int)Mathf.Round(MainMenu.size / 2));
    }
}
