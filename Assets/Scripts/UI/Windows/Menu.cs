using System;
using UnityEngine;
using UnityEngine.UI;
// удалить
public class Menu : MonoBehaviour
{
    [SerializeField] private BallMovement _ball;

    [Header ("RestartMenu")]
    [SerializeField] private GameObject _restartMenu;
    [SerializeField] private Button _restartAfterDie;
    [SerializeField] private Text _scoreText;
    [SerializeField] private LevelsLoader _loader;

    [Header ("Score Panel")]
    [SerializeField] private ScorePanel _scorePanel;
    [SerializeField] private ScoreBank _scoreBank;

    [Header("Finish Menu")]
    [SerializeField] private GameObject _finishMenu;
    [SerializeField] private Button _restartAfterWin;
    [SerializeField] private Text _finishScoreText;
    [SerializeField] private FinishTrigger _finish;

    public event Action MenuOpened;
    public event Action MenuClosed;

    private void Start()
    {
        _restartMenu.SetActive(false);

        _finishMenu.SetActive(false);
    }

    private void OnEnable()
    {
        _ball.OnDied += OpenRestartMenu;

        _restartAfterDie.onClick.AddListener(Restart);

        _restartAfterWin.onClick.AddListener(Restart);

        _finish.OnFinish += OnFinish;
    }

    private void OnDisable()
    {
        _ball.OnDied -= OpenRestartMenu;

        _restartAfterDie.onClick.RemoveListener(Restart);

        _restartAfterWin.onClick.RemoveListener(Restart);

        _finish.OnFinish -= OnFinish;
    }

    private void OnFinish()
    {
        MenuOpened?.Invoke();
        _scorePanel.gameObject.SetActive(false);
        _finishMenu.SetActive(true);
        _finishScoreText.text = _scoreBank.Score.ToString();
    }

    private void OpenMenu()
    {
        MenuOpened?.Invoke();
        Time.timeScale = 0;
    }

    private void CloseMenu()
    {
        MenuClosed?.Invoke();
        Time.timeScale = 1;
    }

    private void OpenRestartMenu()
    {
        MenuOpened?.Invoke();
        _scorePanel.gameObject.SetActive(false);
        _restartMenu.SetActive(true);
        Time.timeScale = 0;
        _scoreText.text = _scoreBank.Score.ToString();       
    }



    private void Restart()
    {
        Time.timeScale = 1;
        _loader.Restart();
    }
}
