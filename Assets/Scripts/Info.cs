using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class Info : MonoBehaviour
{

    public Text LivesText;
    public Text ScoreText;
    public Text VirtualCubeText;
    public Text VirtualCylinderText;

    public static int lives;
    public static int score;
    public static int VirtualCubes;
    public static int VirtualCylinders;
    public static int extraShapes;
    float currentlevel = 2;

    public bool is_Grounded;
    public LayerMask layers;
    public FirstPersonController FPS;
    bool on_air = false;
    bool fall = false;
    bool only_once = true;

    void Start()
    {
        score = 100;
        lives = 4;
        VirtualCubes = 0;
        VirtualCylinders = 0;
        extraShapes = 0;

        LivesText.text = "Lives: " + lives.ToString();
        ScoreText.text = "Score: " + score.ToString();
        VirtualCubeText.text = "Virtual Cubes: " + VirtualCubes.ToString();
        VirtualCylinderText.text = "Virtual Cylinders: " + VirtualCylinders.ToString();
    }

    void Update()
    {
        is_Grounded = FPS.m_PreviouslyGrounded;
        if (!is_Grounded)
        {
            on_air = true;
        }
        if (is_Grounded && fall)
        {
            fall = false;
            currentlevel = Mathf.Round(transform.position.y);
        }
        if (on_air && is_Grounded)
        {
            if (!fall)
            {
                if ((int)Mathf.Round(transform.position.y) > MainMenu.size && only_once)
                {
                    score = score + 100;
                    lives++;
                    only_once = false;
                }
                else if (Mathf.Round(transform.position.y) < currentlevel)
                {
                    if ((score - ((int)currentlevel - (int)Mathf.Round(transform.position.y) - 1) * 10) < 0)
                    {
                        lives--;
                        if (lives == 0)
                        {
                            SceneManager.LoadScene("GameOver");
                        }
                    }
                    else
                    {
                        score = score - ((int)currentlevel - (int)Mathf.Round(transform.position.y) - 1) * 10;
                    }
                }
                else if (Mathf.Round(transform.position.y) > currentlevel)
                {
                    score = score + 10;
                }
                currentlevel = Mathf.Round(transform.position.y);
            }
            on_air = false;
        }

        if (transform.position.y < 0)
        {
            on_air = false;
            lives--;
            if (lives == 0)
            {
                SceneManager.LoadScene("GameOver");
            }
            else
            {
                fall = true;
                transform.position = new Vector3((int)Mathf.Round(MainMenu.size / 2), 2, (int)Mathf.Round(MainMenu.size / 2));
            }
        }

        LivesText.text = "Lives: " + lives.ToString();
        ScoreText.text = "Score: " + score.ToString();
        VirtualCubeText.text = "Virtual Cubes: " + VirtualCubes.ToString();
        VirtualCylinderText.text = "Virtual Cylinders: " + VirtualCylinders.ToString();
    }
}
