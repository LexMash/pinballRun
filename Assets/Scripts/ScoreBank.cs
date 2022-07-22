using UnityEngine;
using System;
using System.Collections;

public class ScoreBank : MonoBehaviour
{
    [SerializeField] private BallCollision _ball;

    public event Action<int> ScoreCollected;
    public event Action<int,float> ReceivedScoreMultiplied;
    public int Score => _score;
    private int _score;

    private int _multiplier = 1;

    private Coroutine _timerRoutine;
    private WaitForSeconds _time;

    private bool _isScoreMultiplied;

    private void OnEnable()
    {
        _ball.ScoreCollected += CollectScore;
    }

    private void OnDisable()
    {
        _ball.ScoreCollected -= CollectScore;
    }

    public void StartIncreaseScore(int multiplier, float time)
    {
        if (!_isScoreMultiplied)
        {
            ReceivedScoreMultiplied?.Invoke(multiplier, time);
            _isScoreMultiplied = true;
            _multiplier = multiplier;
            _time = new WaitForSeconds(time);
            _timerRoutine = StartCoroutine(MultiplierTimer());
        }
        else
        {
            StopRoutine();
            _isScoreMultiplied = false;
            StartIncreaseScore(multiplier, time);
        }
    }

    private void CollectScore()
    {
        _score += (1 * _multiplier); ;
        ScoreCollected?.Invoke(_score);
    }

    private IEnumerator MultiplierTimer()
    {
        yield return _time;
        _multiplier = 1;
        yield break;
    }

    private void StopRoutine()
    {
        StopCoroutine(_timerRoutine);
    }
}
