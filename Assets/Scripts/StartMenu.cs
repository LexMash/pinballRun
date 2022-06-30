using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject _startMenu;
    [SerializeField] private Button _start;
    [SerializeField] private Text _timer;
    [SerializeField] private GameObject _timerWidget;

    private Coroutine _startRoutine;

/*    private void Awake()
    {
        _timerWidget.SetActive(false);
        _startMenu.SetActive(true);
        Time.timeScale = 0;
    }*/

    private void OnEnable()
    {
        _start.onClick.AddListener(StartGame);
    }
    private void OnDisable()
    {
        _start.onClick.RemoveListener(StartGame);
    }

    public void StartGame()
    {
        _startMenu.SetActive(false);
        _timerWidget.SetActive(true);
        _startRoutine = StartCoroutine(CountDown());
    }

    private IEnumerator CountDown()
    {
        string[] words = { "Ready?", "Steady", "GO!" };

        WaitForSecondsRealtime second = new WaitForSecondsRealtime(1f);

        for(int i = 0; i < words.Length; i++)
        {
            _timer.text = words[i];
            yield return second;
        }

        Time.timeScale = 1;
        _timerWidget.SetActive(false);
        StopRoutine();
    }

    private void StopRoutine()
    {
        StopCoroutine(_startRoutine);
    }
}
