using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [HideInInspector] public GameController instance;
    [HideInInspector] public int score;
    [HideInInspector] public bool gameRunning; //Flag that stops game functionality (snake movement, fruit spawning)
    private bool gamePaused; //Flag for beginning of game
    private float timer;

    

    [SerializeField] private GameObject _scoreText;
    [SerializeField] private GameObject _pausedText;
    void Start()
    {
        instance = this; //Initialize singleton
        score = 0;
        gameRunning = false;
        gamePaused = true;
    }
    void Update()
    {
        if (gamePaused)
        {
            if (Input.anyKeyDown) //check if user input, and start game
            {
                gamePaused = false;
                gameRunning = true;
                _pausedText.SetActive(false);
            }
            else return; //if game still paused, still update
        }

        timer += Time.deltaTime;
        if (timer < 1) return;
        timer -= 1;
        if (score <= 0) return;
        score -= 1;
    }
}
