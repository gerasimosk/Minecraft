using System;
using UnityEngine;

public class ColorShape
{
    private GameObject shape;
    private int color;
    private int x, z;
    private float y;

    public ColorShape(int c, int temp_x, float temp_y, int temp_z)
    {
        x = temp_x;
        y = temp_y;
        z = temp_z;

        if (c == 0)
        {
            shape = GameObject.Instantiate(Resources.Load("RedCube")) as GameObject;
            color = 0;
        }
        else if (c == 1)
        {
            shape = GameObject.Instantiate(Resources.Load("BlueCube")) as GameObject;
            color = 1;
        }
        else if (c == 2)
        {
            shape = GameObject.Instantiate(Resources.Load("GreenCube")) as GameObject;
            color = 2;
        }
        else if (c == 3)
        {
            shape = GameObject.Instantiate(Resources.Load("YellowCube")) as GameObject;
            color = 3;
        }
        else if (c == 4)
        {
            shape = GameObject.Instantiate(Resources.Load("LightBlueCube")) as GameObject;
            color = 4;
        }
        else if (c == 5)
        {
            shape = GameObject.Instantiate(Resources.Load("MagentaCube")) as GameObject;
            color = 5;
        }
        else if (c == 6)
        {
            shape = GameObject.Instantiate(Resources.Load("Cylinder")) as GameObject;
            color = 6;
        }
        if (c != 7)
        {
            shape.transform.position = new Vector3(x, y, z);
        }
    }

    public void setY(float newY)
    {
        y = newY;
    }

    public GameObject getObject()
    {
        return shape;
    }

    public int getX()
    {
        return x;
    }

    public float getY()
    {
        return y;
    }

    public int getZ()
    {
        return z;
    }

    public int getColor()
    {
        return color;
    }

    public void setColor(int newColor)
    {
        color = newColor;
    }
}