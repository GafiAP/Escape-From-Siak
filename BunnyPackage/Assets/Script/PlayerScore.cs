using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    public int score;
    public int targetScore;
    public TextMeshProUGUI scoreText;
    public GameObject winScene , loseScene;

    public Warewolf warewolf;
    public Goblin goblin;
    PlayerMovement playerMovement;
    public AudioClip key,win,lose;

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
            Destroy(bgm);
            AudioSource.PlayClipAtPoint(win,Camera.main.transform.position);
            winScene.SetActive(true);
            warewolf.winlose = false;
            goblin.winlose = false;
            playerMovement.winlose = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Score"))
        {
            AudioSource.PlayClipAtPoint(key,Camera.main.transform.position);
            score++;
            scoreText.text = " = " + score.ToString();
            Destroy(col.gameObject);
            Debug.Log(scoreText.text);
        }

        if (col.gameObject.CompareTag("Enemy"))
        {
            Destroy(bgm);
            AudioSource.PlayClipAtPoint(lose,Camera.main.transform.position);
            loseScene.SetActive(true);
            warewolf.winlose = false;
            goblin.winlose = false;
            playerMovement.winlose = true;
            Debug.Log("kena");
        }
    }
}
