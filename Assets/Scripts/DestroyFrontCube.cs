using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyFrontCube : MonoBehaviour{

    private int x, z;
    private float angle;
    float find_x, find_y, find_z;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1.8f))
            {
                find_x = hit.transform.GetComponent<Transform>().position.x;
                find_y = hit.transform.GetComponent<Transform>().position.y;
                find_z = hit.transform.GetComponent<Transform>().position.z;
                if (find_x <= MainMenu.size - 1 && find_x >= 0 && find_z <= MainMenu.size - 1 && find_z >= 0)
                {
                    int x1 = (int)find_x;
                    int y1 = (int)find_y;
                    int z1 = (int)find_z;
                    if (y1 == (int)Mathf.Round(transform.position.y))
                    {
                        destroyFront(x1, y1, z1);
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
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

            if (angle >= 35 && angle <= 60)
            {
                destroyAll(x + 1, z + 1);
            }
            else if (angle > 60 && angle <= 110)
            {
                destroyAll(x + 1, z);
            }
            else if (angle > 110 && angle <= 145)
            {
                destroyAll(x + 1, z - 1);
            }
            else if (angle > 145 && angle <= 195)
            {
                destroyAll(x, z - 1);
            }
            else if (angle > 195 && angle <= 245)
            {
                destroyAll(x - 1, z - 1);
            }
            else if (angle > 245 && angle <= 285)
            {
                destroyAll(x - 1, z);
            }
            else if (angle > 285 && angle <= 325)
            {
                destroyAll(x - 1, z + 1);
            }
            else if (angle > 325 && angle <= 360 || (angle > 0 && angle <= 35))
            {
                destroyAll(x, z + 1);
            }
        }
    }

    void destroyFront(int temp_x, int temp_y, int temp_z)
    {
        for (int j = 0; j < (MainMenu.size * MainMenu.size) + Info.extraShapes; j++)
        {
            if (MakeTheScene.shapes[j].getX() == temp_x && MakeTheScene.shapes[j].getY() == temp_y && MakeTheScene.shapes[j].getZ() == temp_z && MakeTheScene.shapes[j].getColor() != 6 && MakeTheScene.shapes[j].getColor() != 7)
            {
                Destroy(MakeTheScene.shapes[j].getObject());
                MakeTheScene.shapes[j].setColor(7);
            }
        }
    }

    void destroyAll(int temp_x,int temp_z)
    {
        bool found = false;
        for (int j = 0; j < (MainMenu.size * MainMenu.size) + Info.extraShapes; j++)
        {
            if (MakeTheScene.shapes[j].getX() == temp_x && MakeTheScene.shapes[j].getZ() == temp_z && MakeTheScene.shapes[j].getColor() != 5 && MakeTheScene.shapes[j].getColor() != 6 && MakeTheScene.shapes[j].getColor() != 7)
            {
                Destroy(MakeTheScene.shapes[j].getObject());
                MakeTheScene.shapes[j].setColor(7);
                found = true;
            }
        }
        if (found)
        {
            Info.lives++;
            if ((Info.score - 20) < 0)
            {
                Info.lives--;
                if (Info.lives == 0)
                {
                    SceneManager.LoadScene("GameOver");
                }
            }
            else
            {
                Info.score = Info.score - 20;
            }
        }
    }
}
