using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public Animator anim;
    public Animator animExit;
    private void Start()
    {
        Time.timeScale = 1;
    }
    public void level1()
    {
        anim.SetTrigger("Clicked");
        StartCoroutine(Level1());

    }
    public void level2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        animExit.SetTrigger("Clicked");
        StartCoroutine(ExitGame());
    }
    IEnumerator Level1()
    {
        yield return new WaitForSeconds(1f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    IEnumerator ExitGame()
    {
        yield return new WaitForSeconds(1f);
        Application.Quit();
    }
}
