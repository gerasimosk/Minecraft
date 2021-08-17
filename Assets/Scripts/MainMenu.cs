using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static int size = 15;
    int temp;

    public void getInput(string input)
    {
        if (int.TryParse(input, out temp))
        {
            if (temp > 0)
            {
                size = int.Parse(input);
                SceneManager.LoadScene("Game");
            }
        }
    }

    public void goToInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }
}
