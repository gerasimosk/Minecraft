using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick_Cube : MonoBehaviour
{

    private ColorShape shape;
    private float angle;
    private int x, y, z;

    void Update()
    {
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                angle = transform.eulerAngles.y;

                y = (int)Mathf.Round(transform.position.y);
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

                if (angle > 60 && angle <= 110)
                {
                    kickCube(x + 1, y, z, 1);
                }
                else if (angle > 145 && angle <= 195)
                {
                    kickCube(x, y, z - 1, 2);
                }
                else if (angle > 245 && angle <= 285)
                {
                    kickCube(x - 1, y, z, 3);
                }
                else if (angle > 325 && angle <= 360 || (angle > 0 && angle <= 35))
                {
                    kickCube(x, y, z + 1, 4);
                }
            }
        }
    }


    void kickCube(int temp_x, int temp_y, int temp_z, int occasion)
    {
        for (int j = 0; j < (MainMenu.size * MainMenu.size) + Info.extraShapes; j++)
        {
            if (MakeTheScene.shapes[j].getX() == temp_x && MakeTheScene.shapes[j].getY() == temp_y && MakeTheScene.shapes[j].getZ() == temp_z && MakeTheScene.shapes[j].getColor() != 6 && MakeTheScene.shapes[j].getColor() != 7)
            {
                if (occasion == 1)
                {
                    List<int> continuously = new List<int>();
                    for (int i = temp_x; i < MainMenu.size; i++)
                    {
                        int x = exists(i, temp_y, temp_z);
                        if (x != -1)
                        {
                            continuously.Add(x);
                        }
                        else
                        {
                            break;
                        }
                    }
                    for (int i = MainMenu.size - 1; i >= temp_x; i--)
                    {
                        for (int k = 0; k < (MainMenu.size * MainMenu.size) + Info.extraShapes; k++)
                        {
                            if (MakeTheScene.shapes[k].getX() == i && MakeTheScene.shapes[k].getY() == temp_y && MakeTheScene.shapes[k].getZ() == temp_z && MakeTheScene.shapes[k].getColor() != 6 && MakeTheScene.shapes[k].getColor() != 7 && continuously.IndexOf(k) != -1)
                            {
                                if (i != MainMenu.size - 1)
                                {
                                    shape = new ColorShape(MakeTheScene.shapes[k].getColor(), MakeTheScene.shapes[k].getX() + 1, y, z);
                                    if (PlaceShape.shapesLevel[i + 1, z] < temp_y)
                                    {
                                        PlaceShape.shapesLevel[i + 1, z] = temp_y - 1;
                                    }
                                    if (PlaceShape.shapesLevel[i, z] == temp_y - 1)
                                    {
                                        PlaceShape.shapesLevel[i, z]--;
                                    }
                                    MakeTheScene.shapes.Add(shape);
                                    Info.extraShapes++;
                                    Destroy(MakeTheScene.shapes[k].getObject());
                                    MakeTheScene.shapes[k].setColor(7);
                                }
                                else
                                {
                                    Destroy(MakeTheScene.shapes[k].getObject());
                                    MakeTheScene.shapes[k].setColor(7);
                                    if (PlaceShape.shapesLevel[i, z] == temp_y - 1)
                                    {
                                        PlaceShape.shapesLevel[i, z]--;
                                    }
                                }
                            }
                        }
                    }
                }
                else if (occasion == 2)
                {
                    List<int> continuously = new List<int>();
                    for (int i = temp_z; i >= 0; i--)
                    {
                        int x = exists(temp_x, temp_y, i);
                        if (x != -1)
                        {
                            continuously.Add(x);
                        }
                        else
                        {
                            break;
                        }
                    }
                    for (int i = 0; i <= temp_z; i++)
                    {
                        for (int k = 0; k < (MainMenu.size * MainMenu.size) + Info.extraShapes; k++)
                        {
                            if (MakeTheScene.shapes[k].getX() == temp_x && MakeTheScene.shapes[k].getY() == temp_y && MakeTheScene.shapes[k].getZ() == i && MakeTheScene.shapes[k].getColor() != 6 && MakeTheScene.shapes[k].getColor() != 7 && continuously.IndexOf(k) != -1)
                            {
                                if (i != 0)
                                {
                                    shape = new ColorShape(MakeTheScene.shapes[k].getColor(), x, y, MakeTheScene.shapes[k].getZ() - 1);
                                    if (PlaceShape.shapesLevel[x, i - 1] < temp_y)
                                    {
                                        PlaceShape.shapesLevel[x, i - 1] = temp_y - 1;
                                    }
                                    if (PlaceShape.shapesLevel[x, i] == temp_y - 1)
                                    {
                                        PlaceShape.shapesLevel[x, i]--;
                                    }
                                    MakeTheScene.shapes.Add(shape);
                                    Info.extraShapes++;
                                    Destroy(MakeTheScene.shapes[k].getObject());
                                    MakeTheScene.shapes[k].setColor(7);
                                }
                                else
                                {
                                    Destroy(MakeTheScene.shapes[k].getObject());
                                    MakeTheScene.shapes[k].setColor(7);
                                    if (PlaceShape.shapesLevel[x, i] == temp_y - 1)
                                    {
                                        PlaceShape.shapesLevel[x, i]--;
                                    }
                                }
                            }
                        }
                    }
                }
                else if (occasion == 3)
                {
                    List<int> continuously = new List<int>();
                    for (int i = temp_x; i >= 0; i--)
                    {
                        int x = exists(i, temp_y, temp_z);
                        if (x != -1)
                        {
                            continuously.Add(x);
                        }
                        else
                        {
                            break;
                        }
                    }
                    for (int i = 0; i <= temp_x; i++)
                    {
                        for (int k = 0; k < (MainMenu.size * MainMenu.size) + Info.extraShapes; k++)
                        {
                            if (MakeTheScene.shapes[k].getX() == i && MakeTheScene.shapes[k].getY() == temp_y && MakeTheScene.shapes[k].getZ() == temp_z && MakeTheScene.shapes[k].getColor() != 6 && MakeTheScene.shapes[k].getColor() != 7 && continuously.IndexOf(k) != -1)
                            {
                                if (i != 0)
                                {
                                    shape = new ColorShape(MakeTheScene.shapes[k].getColor(), MakeTheScene.shapes[k].getX() - 1, y, z);
                                    if (PlaceShape.shapesLevel[i - 1, z] < temp_y)
                                    {
                                        PlaceShape.shapesLevel[i - 1, z] = temp_y - 1;
                                    }
                                    if (PlaceShape.shapesLevel[i, z] == temp_y - 1)
                                    {
                                        PlaceShape.shapesLevel[i, z]--;
                                    }
                                    MakeTheScene.shapes.Add(shape);
                                    Info.extraShapes++;
                                    Destroy(MakeTheScene.shapes[k].getObject());
                                    MakeTheScene.shapes[k].setColor(7);
                                }
                                else
                                {
                                    Destroy(MakeTheScene.shapes[k].getObject());
                                    MakeTheScene.shapes[k].setColor(7);
                                    if (PlaceShape.shapesLevel[i, z] == temp_y - 1)
                                    {
                                        PlaceShape.shapesLevel[i, z]--;
                                    }
                                }
                            }
                        }
                    }
                }
                else if (occasion == 4)
                {
                    List<int> continuously = new List<int>();
                    for (int i = temp_z; i < MainMenu.size; i++)
                    {
                        int x = exists(temp_x, temp_y, i);
                        if (x != -1)
                        {
                            continuously.Add(x);
                        }
                        else
                        {
                            break;
                        }
                    }
                    for (int i = MainMenu.size - 1; i >= temp_z; i--)
                    {
                        for (int k = 0; k < (MainMenu.size * MainMenu.size) + Info.extraShapes; k++)
                        {
                            if (MakeTheScene.shapes[k].getX() == temp_x && MakeTheScene.shapes[k].getY() == temp_y && MakeTheScene.shapes[k].getZ() == i && MakeTheScene.shapes[k].getColor() != 6 && MakeTheScene.shapes[k].getColor() != 7 && continuously.IndexOf(k) != -1)
                            {
                                if (i != MainMenu.size - 1)
                                {
                                    shape = new ColorShape(MakeTheScene.shapes[k].getColor(), x, y, MakeTheScene.shapes[k].getZ() + 1);
                                    if (PlaceShape.shapesLevel[x, i + 1] < temp_y)
                                    {
                                        PlaceShape.shapesLevel[x, i + 1] = temp_y - 1;
                                    }
                                    if (PlaceShape.shapesLevel[x, i] == temp_y - 1)
                                    {
                                        PlaceShape.shapesLevel[x, i]--;
                                    }
                                    MakeTheScene.shapes.Add(shape);
                                    Info.extraShapes++;
                                    Destroy(MakeTheScene.shapes[k].getObject());
                                    MakeTheScene.shapes[k].setColor(7);
                                }
                                else
                                {
                                    Destroy(MakeTheScene.shapes[k].getObject());
                                    MakeTheScene.shapes[k].setColor(7);
                                    if (PlaceShape.shapesLevel[x, i] == temp_y - 1)
                                    {
                                        PlaceShape.shapesLevel[x, i]--;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

    }

    int exists(int xtemp, int ytemp, int ztemp)
    {
        for (int i = 0; i < (MainMenu.size * MainMenu.size) + Info.extraShapes; i++)
        {
            if (MakeTheScene.shapes[i].getX() == xtemp && MakeTheScene.shapes[i].getY() == ytemp && MakeTheScene.shapes[i].getZ() == ztemp && MakeTheScene.shapes[i].getColor() != 6 && MakeTheScene.shapes[i].getColor() != 7)
            {
                return i;
            }
        }
        return -1;
    }

}
