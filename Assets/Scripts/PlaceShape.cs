using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceShape : MonoBehaviour
{
    ColorShape shape;
    int color;
    float angle;
    int x, z;
    public static int[,] shapesLevel;

    void Start()
    {
        shapesLevel = new int[MainMenu.size, MainMenu.size];
    }

    void Update()
    {
        if (Info.VirtualCubes > 0)
        {
            if (Input.GetKeyDown(KeyCode.B)){
                color = Random.Range(0, 5);
                angle = transform.eulerAngles.y;

                float error = 0.5F;
                for (int i = 0; i < MainMenu.size; i++)
                {
                    if (transform.position.x >= i - error && transform.position.x <= i + error)
                    {
                        x = i;
                    }
                    if (transform.position.z >= i - error && transform.position.z <= i + error)
                    {
                        z = i;
                    }
                }

                if (angle >= 35 && angle <= 60){
                    if (x + 1 < MainMenu.size && z + 1 < MainMenu.size)
                    {
                        if (shapesLevel[x + 1, z + 1] != MainMenu.size - 1)
                        {
                            PlaceCube(x + 1, shapesLevel[x + 1, z + 1] + 2, z + 1);
                        }
                    }
                }
                else if (angle > 60 && angle <= 110)
                {
                    if (x + 1 < MainMenu.size)
                    {
                        if (shapesLevel[x + 1, z] != MainMenu.size - 1)
                        {
                            PlaceCube(x + 1, shapesLevel[x + 1, z] + 2, z);
                        }
                    }
                }
                else if (angle > 110 && angle <= 145)
                {
                    if (x + 1 < MainMenu.size && z - 1 >= 0)
                    {
                        if (shapesLevel[x + 1, z - 1] != MainMenu.size - 1)
                        {
                            PlaceCube(x + 1, shapesLevel[x + 1, z - 1] + 2, z - 1);
                        }
                    }
                }
                else if (angle > 145 && angle <= 195)
                {
                    if (z - 1 >= 0)
                    {
                        if (shapesLevel[x, z - 1] != MainMenu.size - 1)
                        {
                            PlaceCube(x, shapesLevel[x, z - 1] + 2, z - 1);
                        }
                    }
                }
                else if (angle > 195 && angle <= 245)
                {
                    if (z - 1 >= 0 && x - 1 >= 0)
                    {
                        if (shapesLevel[x - 1, z - 1] != MainMenu.size - 1)
                        {
                            PlaceCube(x - 1, shapesLevel[x - 1, z - 1] + 2, z - 1);
                        }
                    }
                }
                else if (angle > 245 && angle <= 285)
                {
                    if (x - 1 >= 0)
                    {
                        if (shapesLevel[x - 1, z] != MainMenu.size - 1)
                        {
                            PlaceCube(x - 1, shapesLevel[x - 1, z] + 2, z);
                        }
                    }
                }
                else if (angle > 285 && angle <= 325)
                {
                    if (x - 1 >= 0 && z + 1 < MainMenu.size)
                    {
                        if (shapesLevel[x - 1, z + 1] != MainMenu.size - 1)
                        {
                            PlaceCube(x - 1, shapesLevel[x - 1, z + 1] + 2, z + 1);
                        }
                    }
                }
                else if (angle > 325 && angle <= 360 || (angle > 0 && angle <= 35))
                {
                    if (z + 1 < MainMenu.size)
                    {
                        if (shapesLevel[x, z + 1] != MainMenu.size - 1)
                        {
                            PlaceCube(x, shapesLevel[x, z + 1] + 2, z + 1);
                        }
                    }
                }
            }
        }
        if (Info.VirtualCylinders > 0)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                angle = transform.eulerAngles.y;

                float error = 0.5F;
                for (int i = 0; i < MainMenu.size; i++)
                {
                    if (transform.position.x >= i - error && transform.position.x <= i + error)
                    {
                        x = i;
                    }
                    if (transform.position.z >= i - error && transform.position.z <= i + error)
                    {
                        z = i;
                    }
                }

                if (angle > 35 && angle <= 60)
                {
                    if (x + 1 < MainMenu.size && z + 1 < MainMenu.size)
                    {
                        if (shapesLevel[x + 1, z + 1] != MainMenu.size - 2 && shapesLevel[x + 1, z + 1] != MainMenu.size - 1)
                        {
                            PlaceCylinder(x + 1, shapesLevel[x + 1, z + 1] + 2, z + 1);
                        }
                    }
                }
                else if (angle > 60 && angle <= 110)
                {
                    if (x + 1 < MainMenu.size)
                    {
                        if (shapesLevel[x + 1, z] != MainMenu.size - 2 && shapesLevel[x + 1, z] != MainMenu.size - 1)
                        {
                            PlaceCylinder(x + 1, shapesLevel[x + 1, z] + 2, z);
                        }
                    }
                }
                else if (angle > 110 && angle <= 145)
                {
                    if (x + 1 < MainMenu.size && z - 1 >= 0)
                    {
                        if (shapesLevel[x + 1, z - 1] != MainMenu.size - 2 && shapesLevel[x + 1, z - 1] != MainMenu.size - 1)
                        {
                            PlaceCylinder(x + 1, shapesLevel[x + 1, z - 1] + 2, z - 1);
                        }
                    }
                }
                else if (angle > 145 && angle <= 195)
                {
                    if (z - 1 >= 0)
                    {
                        if (shapesLevel[x, z - 1] != MainMenu.size - 2 && shapesLevel[x, z - 1] != MainMenu.size - 1)
                        {
                            PlaceCylinder(x, shapesLevel[x, z - 1] + 2, z - 1);
                        }
                    }
                }
                else if (angle > 195 && angle <= 245)
                {
                    if (z - 1 >= 0 && x - 1 >= 0)
                    {
                        if (shapesLevel[x - 1, z - 1] != MainMenu.size - 2 && shapesLevel[x - 1, z - 1] != MainMenu.size - 1)
                        {
                            PlaceCylinder(x - 1, shapesLevel[x - 1, z - 1] + 2, z - 1);
                        }
                    }
                }
                else if (angle > 245 && angle <= 285)
                {
                    if (x - 1 >= 0)
                    {
                        if (shapesLevel[x - 1, z] != MainMenu.size - 2 && shapesLevel[x - 1, z] != MainMenu.size - 1)
                        {
                            PlaceCylinder(x - 1, shapesLevel[x - 1, z] + 2, z);
                        }
                    }
                }
                else if (angle > 285 && angle <= 325)
                {
                    if (x - 1 >= 0 && z + 1 < MainMenu.size)
                    {
                        if (shapesLevel[x - 1, z + 1] != MainMenu.size - 2 && shapesLevel[x - 1, z + 1] != MainMenu.size - 1)
                        {
                            PlaceCylinder(x - 1, shapesLevel[x - 1, z + 1] + 2, z + 1);
                        }
                    }
                }
                else if (angle > 325 && angle <= 360 ||(angle > 0 && angle <= 35))
                {
                    if (z + 1 < MainMenu.size)
                    {
                        if (shapesLevel[x, z + 1] != MainMenu.size - 2 && shapesLevel[x, z + 1] != MainMenu.size - 1)
                        {
                            PlaceCylinder(x, shapesLevel[x, z + 1] + 2, z + 1);
                        }
                    }
                }
            }
        }
    }

    void PlaceCube(int x, int y, int z)
    {
        shape = new ColorShape(color,x,y,z);
        shapesLevel[x,z] = shapesLevel[x, z] + 1;
        MakeTheScene.shapes.Add(shape);
        Info.extraShapes++;
        Info.VirtualCubes--;
        Info.score = Info.score + 10;
    }

    void PlaceCylinder(int x, int y, int z)
    {
        float temp = y + 0.5F;
        shape = new ColorShape(6, x, temp, z);
        shapesLevel[x, z] = shapesLevel[x, z] + 2;
        MakeTheScene.shapes.Add(shape);
        Info.extraShapes++;
        Info.VirtualCylinders--;
        Info.score = Info.score + 20;
    }
}