using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMultyplierWidget : MonoBehaviour
{
    [SerializeField] private Text _multiplier;
    [SerializeField] private ScoreBank _bank;

    private Coroutine _multipliedRoutine;

    private bool _isRoutined;

    private void Start()
    {
        _multiplier.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        _bank.ReceivedScoreMultiplied += ReceivedScoreMultiplied;
    }
    private void OnDisable()
    {
        _bank.ReceivedScoreMultiplied -= ReceivedScoreMultiplied;
    }
    private void ReceivedScoreMultiplied(int multiplier, float time)
    {
        if (!_isRoutined)
        {
            _multiplier.gameObject.SetActive(true);
            _isRoutined = true;
            _multiplier.text = "x" + multiplier;
            _multipliedRoutine = StartCoroutine(MultipliedRoutine(time));
        }
        else
        {
            StopRoutine();
            ReceivedScoreMultiplied(multiplier, time);
        }
    }

    private IEnumerator MultipliedRoutine(float time)
    {
        yield return new WaitForSeconds(time);
        _isRoutined = false;
        _multiplier.gameObject.SetActive(false);
        yield break;
    }

    private void StopRoutine()
    {
        StopCoroutine(_multipliedRoutine);
    }
}
