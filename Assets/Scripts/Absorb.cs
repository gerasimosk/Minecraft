using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Absorb : MonoBehaviour
{
    private ColorShape shape;
    int find_x, find_y, find_z;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, 1.5f))
            {
                find_x = (int)hit.transform.GetComponent<Transform>().position.x;
                find_y = (int)hit.transform.GetComponent<Transform>().position.y;
                find_z = (int)hit.transform.GetComponent<Transform>().position.z;
                findShape();
            }
        }
    }

    void findShape()
    {
        for (int j = 0; j < (MainMenu.size * MainMenu.size) + Info.extraShapes; j++)
        {
            if (MakeTheScene.shapes[j].getX() == find_x && MakeTheScene.shapes[j].getY() == find_y && MakeTheScene.shapes[j].getZ() == find_z && MakeTheScene.shapes[j].getColor() !=6 && MakeTheScene.shapes[j].getColor() != 7)
            {
                if (MakeTheScene.shapes[j].getColor() == 3)
                {  
                    Destroy(MakeTheScene.shapes[j].getObject());
                    shape = new ColorShape(1, find_x, find_y, find_z);
                    MakeTheScene.shapes.Add(shape);
                    Info.extraShapes++;
                    MakeTheScene.shapes[j].setColor(7);
                    Info.VirtualCubes = Info.VirtualCubes + 1;
                    if (Info.score - 5 >= 0)
                    {
                        Info.score = Info.score - 5;
                    }
                    else
                    {
                        Info.lives = Info.lives - 1;
                        if (Info.lives == 0)
                        {
                            if (Info.lives == 0)
                            {
                                SceneManager.LoadScene("GameOver");
                            }
                        }
                    }
                    break;
                }
                else if (MakeTheScene.shapes[j].getColor() == 0)
                {
                    Destroy(MakeTheScene.shapes[j].getObject());
                    shape = new ColorShape(3, find_x, find_y, find_z);
                    MakeTheScene.shapes.Add(shape);
                    Info.extraShapes++;
                    MakeTheScene.shapes[j].setColor(7);
                    Info.VirtualCubes = Info.VirtualCubes + 1;
                    if (Info.score - 5 >= 0)
                    {
                        Info.score = Info.score - 5;
                    }
                    else
                    {
                        Info.lives = Info.lives - 1;
                        if (Info.lives == 0)
                        {
                            if (Info.lives == 0)
                            {
                                SceneManager.LoadScene("GameOver");
                            }
                        }
                    }
                    break;
                }
                else if (MakeTheScene.shapes[j].getColor() == 2)
                {
                    Destroy(MakeTheScene.shapes[j].getObject());
                    shape = new ColorShape(0, find_x, find_y, find_z);
                    MakeTheScene.shapes.Add(shape);
                    Info.extraShapes++;
                    MakeTheScene.shapes[j].setColor(7);
                    Info.VirtualCubes = Info.VirtualCubes + 1;
                    if (Info.score - 5 >= 0)
                    {
                        Info.score = Info.score - 5;
                    }
                    else
                    {
                        Info.lives = Info.lives - 1;
                        if (Info.lives == 0)
                        {
                            SceneManager.LoadScene("GameOver");
                        }
                    }
                    break;
                }
                else if (MakeTheScene.shapes[j].getColor() == 4)
                {
                    Destroy(MakeTheScene.shapes[j].getObject());
                    MakeTheScene.shapes[j].setColor(7);
                    Info.VirtualCylinders = Info.VirtualCylinders + 1;
                    if (Info.score - 5 >= 0)
                    {
                        Info.score = Info.score - 5;
                    }
                    else
                    {
                        Info.lives = Info.lives - 1;
                        if (Info.lives == 0)
                        {
                            SceneManager.LoadScene("GameOver");
                        }
                    }
                    break;
                }
            }
        }
    }
}