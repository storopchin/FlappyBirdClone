using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Score : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private TMP_Text _score;


    public void TextDisableAlpha()
    {
        _score.alpha = 0;
    }
    public void TextEnableAlpha()
    {
        _score.alpha = 1;
    }
    private void OnScoreChanged(int score)
    {
        _score.text = score.ToString();
    }

    private void OnEnable()
    {
        _bird.ScoreChanged += OnScoreChanged;
    }
    private void OnDisable()
    {
        _bird.ScoreChanged -= OnScoreChanged;
    }
}
