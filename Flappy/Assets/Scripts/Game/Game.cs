using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private TubeGeneration _tubeGeneration;

    [SerializeField] private Screen _startScreen;
    [SerializeField] private Screen _gameOverScreen;

    [SerializeField] private Score _score;


    private void StartGame()
    {
        _bird.Enable();
        _bird.ResetPlayer();
        Time.timeScale = 1;
    }
    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
        _score.TextEnableAlpha();
    }
    private void OnRestartButtonClick()
    {
        _gameOverScreen.Close();
        _tubeGeneration.ResetPool();
        _score.TextEnableAlpha();
        StartGame();
    }
    private void OnGameOver()
    {
        Time.timeScale = 0;
        _gameOverScreen.Open();
        _bird.Disable();
        _score.TextDisableAlpha();
    }


    private void OnEnable()
    {
        _startScreen.ButtonClick += OnPlayButtonClick;
        _gameOverScreen.ButtonClick += OnRestartButtonClick;
        _bird.GameOver += OnGameOver;
    }
    private void OnDisable()
    {
        _gameOverScreen.ButtonClick -= OnRestartButtonClick;
        _gameOverScreen.ButtonClick -= OnRestartButtonClick;
        _bird.GameOver -= OnGameOver;
    }
    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
        _score.TextDisableAlpha();
    }
}
