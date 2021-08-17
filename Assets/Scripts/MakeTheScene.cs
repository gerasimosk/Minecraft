using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTheScene : MonoBehaviour
{
    public static List<ColorShape> shapes;

    void Start()
    {
        shapes = new List<ColorShape>();
        ColorShape temp;
        for (int i = 0; i < MainMenu.size; i++){
            for (int j = 0; j < MainMenu.size; j++){
                if (i == Mathf.Round(MainMenu.size / 2) && j == Mathf.Round(MainMenu.size / 2)){
                    temp = new ColorShape(5, i, 1, j);
                    shapes.Add(temp);
                }
                else
                {
                    int randomColor = Random.Range(0, 5);
                    temp = new ColorShape(randomColor, i, 1, j);
                    shapes.Add(temp);
                }
            }
        }
    }
}
