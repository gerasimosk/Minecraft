using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity_Cubes : MonoBehaviour
{
    ColorShape shape;
    Rigidbody rigid;
    GameObject cube;
    bool found = false;

    void Update()
    {
        StartCoroutine(Fall());
    }

    IEnumerator Fall()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            for (int i = MainMenu.size * MainMenu.size; i < MainMenu.size * MainMenu.size + Info.extraShapes; i++)
            {
                if (MakeTheScene.shapes[i].getY() >= 2 && MakeTheScene.shapes[i].getColor() != 6 && MakeTheScene.shapes[i].getColor() != 7)
                {
                    found = true;
                    cube = MakeTheScene.shapes[i].getObject();
                    rigid = cube.GetComponent<Rigidbody>();
                    rigid.useGravity = true;
                    rigid.constraints = ~RigidbodyConstraints.FreezePositionY;
                }
            }
            yield return new WaitForSeconds(1.5f);
            if (found)
            {
                Info.score += 30;
            }
            int tempcount = 0;
            for (int i = MainMenu.size * MainMenu.size; i < MainMenu.size * MainMenu.size + Info.extraShapes; i++)
            {
                if (MakeTheScene.shapes[i].getY() >= 2 && MakeTheScene.shapes[i].getColor() != 6 && MakeTheScene.shapes[i].getColor() != 7)
                {
                    cube = MakeTheScene.shapes[i].getObject();
                    rigid = cube.GetComponent<Rigidbody>();
                    rigid.useGravity = false;
                    rigid.constraints = RigidbodyConstraints.FreezeAll;
                    if (MakeTheScene.shapes[i].getObject().transform.position.y < 0)
                    {
                        Destroy(MakeTheScene.shapes[i].getObject());
                        MakeTheScene.shapes[i].setColor(7);
                    }
                    else
                    {
                        Destroy(MakeTheScene.shapes[i].getObject());
                        int tempx = (int)Mathf.Round(MakeTheScene.shapes[i].getObject().transform.position.x);
                        float tempy = Mathf.Round(MakeTheScene.shapes[i].getObject().transform.position.y);
                        int tempz = (int)Mathf.Round(MakeTheScene.shapes[i].getObject().transform.position.z);
                        shape = new ColorShape(MakeTheScene.shapes[i].getColor(),tempx, tempy, tempz);
                        MakeTheScene.shapes[i].setColor(7);
                        MakeTheScene.shapes.Add(shape);
                        tempcount++;
                    }
                }
            }
            Info.extraShapes = Info.extraShapes + tempcount;
            findNewShapesLevel();
        }
    }

    void findNewShapesLevel()
    {
        for (int i = 0; i < MainMenu.size; i++)
        {
            for (int j = 0; j < MainMenu.size; j++)
            {
                PlaceShape.shapesLevel[i, j] = -1;
            }
        }
        for (int i = 0; i < MainMenu.size * MainMenu.size + Info.extraShapes; i++)
        {
            if (MakeTheScene.shapes[i].getY() -1 > PlaceShape.shapesLevel[MakeTheScene.shapes[i].getX(), MakeTheScene.shapes[i].getZ()] && MakeTheScene.shapes[i].getColor() != 7 && MakeTheScene.shapes[i].getColor() != 6)
            {
                PlaceShape.shapesLevel[MakeTheScene.shapes[i].getX(), MakeTheScene.shapes[i].getZ()] = (int)Mathf.Round(MakeTheScene.shapes[i].getY()) - 1;
            }
            else if (MakeTheScene.shapes[i].getY() - 1 > PlaceShape.shapesLevel[MakeTheScene.shapes[i].getX(), MakeTheScene.shapes[i].getZ()] && MakeTheScene.shapes[i].getColor() != 7 && MakeTheScene.shapes[i].getColor() == 6)
            {
                PlaceShape.shapesLevel[MakeTheScene.shapes[i].getX(), MakeTheScene.shapes[i].getZ()] = (int)Mathf.Round(MakeTheScene.shapes[i].getY());
            }
        }
    }
}