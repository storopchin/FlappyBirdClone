using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private TubeGeneration _tubeGeneration;

    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;


    private void StartGame()
    {
        _bird.ResetPlayer();
        _bird.gameObject.SetActive(true);
        Time.timeScale = 1;
    }
    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }
    private void OnRestartButtonClick()
    {
        _gameOverScreen.Close();
        _tubeGeneration.ResetPool();
        StartGame();
    }
    private void OnGameOver()
    {
        Time.timeScale = 0;
        _gameOverScreen.Open();
        _bird.gameObject.SetActive(false);
    }


    private void OnEnable()
    {
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
        _bird.GameOver += OnGameOver;
    }
    private void OnDisable()
    {
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _bird.GameOver -= OnGameOver;
    }
    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }
}
