using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [HideInInspector] public static GameController instance;
    [HideInInspector] public int score;
    [HideInInspector] public bool gameRunning; //Flag that stops game functionality (snake movement, fruit spawning)
    public AudioSource music;
    public AudioSource startSound;
    private float timer;

    private bool _gamePaused; //Flag for beginning of game

    [Range(1, 50)] public int fruitScore;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private GameObject _pausedText;
    void Start()
    {
        instance = this; //Initialize singleton
        score = 0;
        gameRunning = false;
        _gamePaused = true;
        music.Play();
    }
    void Update()
    {
        if (_gamePaused)
        {
            if (Input.anyKeyDown) //check if user input, and start game
            {
                _gamePaused = false;
                gameRunning = true;
                _pausedText.SetActive(false);
                startSound.Play();
            }
            else return; //if game still paused, still update
        }
        //update score
        timer += Time.deltaTime;
        if (timer > 1)
        {
            timer -= 1;
            if (score > 0) score -= 1;
        }
        _scoreText.text = "Score: " + score;
    }


    public void GameOver()
    {
        gameRunning = false;
        music.Pause();
    }

    public void OnEatFruit()
    {
        score += fruitScore;
    }
}