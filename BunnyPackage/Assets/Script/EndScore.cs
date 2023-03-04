using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScore : MonoBehaviour
{
    public int score;
    public int targetScore;
    public TextMeshProUGUI scoreText;
    public GameObject winScene , loseScene,pauseScene;

    public Warewolf warewolf;
    public Goblin goblin;
    PlayerMovement playerMovement;
    public AudioClip key,win,lose;
    public GameObject penjara;
    public GameObject adik;
    public GameObject objective;
    public GameObject objective1;
    public GameObject bgm;
    void Start()
    {
        score = 0;
        scoreText.text = " = " + score.ToString();
        playerMovement = GetComponent<PlayerMovement>();

    }

    private void Update()
    {
        if (score == targetScore)
        {
            objective1.SetActive(true);
            penjara.SetActive(false);
            adik.GetComponent<BoxCollider2D>().enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseScene.SetActive(true);
            StartCoroutine(PauseGame());
        }
        
    }
    IEnumerator PauseGame()
    {
        yield return new WaitForSeconds(0.25f);
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseScene.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Score"))
        {
            AudioSource.PlayClipAtPoint(key,Camera.main.transform.position);
            score += 1;
            scoreText.text = " = " + score.ToString();
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("Enemy"))
        {
            Destroy(bgm);
            AudioSource.PlayClipAtPoint(lose,Camera.main.transform.position);
            loseScene.SetActive(true);
           
            playerMovement.winlose = true;
            Debug.Log("kena");
        }
        if (col.gameObject.CompareTag("adik"))
        {
            Destroy(bgm);
            AudioSource.PlayClipAtPoint(win, Camera.main.transform.position);
            winScene.SetActive(true);
            playerMovement.winlose = true;
        }
    }
}
