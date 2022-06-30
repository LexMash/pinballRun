using UnityEngine;
using System;
using System.Collections;

public class ScoreBank : MonoBehaviour
{
    [SerializeField] private BallCollision _ball;

    public event Action<int> ScoreChanged;
    public event Action<int,float> ScoreIncreased;
    public int Score => _score;
    private int _score;

    private int _multyplier = 1;

    private Coroutine _timerRoutine;
    private WaitForSeconds _time;

    private bool _isScoreIncreasing;

    private void OnEnable()
    {
        _ball.ScoreCollected += ScoreCollected;
    }

    private void OnDisable()
    {
        _ball.ScoreCollected -= ScoreCollected;
    }

    public void StartIncreaseScore(int multiplier, float time)
    {
        if (!_isScoreIncreasing)
        {
            ScoreIncreased?.Invoke(multiplier, time);
            _isScoreIncreasing = true;
            _multyplier = multiplier;
            _time = new WaitForSeconds(time);
            _timerRoutine = StartCoroutine(IncreaseScoreTimer());
        }
        else
        {
            StopRoutine();
            _isScoreIncreasing = false;
            StartIncreaseScore(multiplier, time);
        }
    }

    private void ScoreCollected()
    {
        _score += (1 * _multyplier); ;
        ScoreChanged?.Invoke(_score);
    }

    private IEnumerator IncreaseScoreTimer()
    {
        yield return _time;
        _multyplier = 1;
        StopRoutine();
    }

    private void StopRoutine()
    {
        StopCoroutine(_timerRoutine);
    }
}
