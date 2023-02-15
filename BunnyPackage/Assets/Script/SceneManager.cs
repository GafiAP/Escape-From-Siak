using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void level1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
    }
    public void level2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
    }

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
