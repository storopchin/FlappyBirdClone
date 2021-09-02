using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChanged;

    private BirdMover _mover;
    private int _score;


    public void IncreaseScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
        Debug.Log(_score);
    }
    public void Die()
    {
        gameObject.SetActive(false);
        GameOver?.Invoke();
    }
    public void ResetPlayer()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
        _mover.ResetBirdToStart();
        gameObject.SetActive(true);
    }
    public void Enable()
    {
        gameObject.SetActive(true);
    }
    public void Disable()
    {
        gameObject.SetActive(false);
    }

    private void Start()
    {
        _mover = GetComponent<BirdMover>();
        gameObject.SetActive(false);
    }
}
