using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMultyplierWidget : MonoBehaviour
{
    [SerializeField] private Text _multiplier;
    [SerializeField] private ScoreBank _bank;

    private Coroutine _scoreRoutine;

    private bool _isRoutined;

    private void Start()
    {
        _multiplier.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        _bank.ScoreIncreased += ScoreIncreased;
    }
    private void OnDisable()
    {
        _bank.ScoreIncreased -= ScoreIncreased;
    }
    private void ScoreIncreased(int multiplier, float time)
    {
        if (!_isRoutined)
        {
            _multiplier.gameObject.SetActive(true);
            _isRoutined = true;
            _multiplier.text = "x" + multiplier.ToString();
            _scoreRoutine = StartCoroutine(ScoreRoutine(time));
        }
        else
        {
            StopRoutine();
            ScoreIncreased(multiplier, time);
        }

    }

    private IEnumerator ScoreRoutine(float time)
    {
        yield return new WaitForSeconds(time);
        _isRoutined = false;
        _multiplier.gameObject.SetActive(false);
        StopRoutine();
    }

    private void StopRoutine()
    {
        StopCoroutine(_scoreRoutine);
    }
}
