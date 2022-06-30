using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private Button _menuButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _soundButton;
    [SerializeField] private Image _soundImage;
    [SerializeField] private Sprite _soundEnable;
    [SerializeField] private Sprite _soundDisable;
    [SerializeField] private BallMovement _ball;

    [Header ("RestartMenu")]
    [SerializeField] private GameObject _restartMenu;
    [SerializeField] private Button _restartAfterDie;
    [SerializeField] private Text _scoreText;

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
        _menu.SetActive(false);
        _finishMenu.SetActive(false);
    }

    private void OnEnable()
    {
        _ball.OnDied += OpenRestartMenu;

        _restartButton.onClick.AddListener(Restart);
        _menuButton.onClick.AddListener(OpenMenu);
        _continueButton.onClick.AddListener(CloseMenu);
        _soundButton.onClick.AddListener(SoundEnable);

        _restartAfterDie.onClick.AddListener(Restart);

        _restartAfterWin.onClick.AddListener(Restart);

        _finish.OnFinish += OnFinish;
    }

    private void OnDisable()
    {
        _ball.OnDied -= OpenRestartMenu;
        _restartButton.onClick.RemoveListener(Restart);
        _menuButton.onClick.RemoveListener(OpenMenu);
        _continueButton.onClick.RemoveListener(CloseMenu);
        _soundButton.onClick.RemoveListener(SoundEnable);

        _restartAfterDie.onClick.RemoveListener(Restart);

        _restartAfterWin.onClick.RemoveListener(Restart);

        _finish.OnFinish -= OnFinish;
    }

    private void OnFinish()
    {
        MenuOpened?.Invoke();
        _scorePanel.gameObject.SetActive(false);
        _menuButton.gameObject.SetActive(false);
        _finishMenu.SetActive(true);
        _finishScoreText.text = _scoreBank.Score.ToString();
    }

    private void OpenMenu()
    {
        MenuOpened?.Invoke();
        _menu.SetActive(true);
        _menuButton.gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    private void CloseMenu()
    {
        MenuClosed?.Invoke();
        _menuButton.gameObject.SetActive(true);
        _menu.SetActive(false);
        Time.timeScale = 1;
    }

    private void OpenRestartMenu()
    {
        MenuOpened?.Invoke();
        _scorePanel.gameObject.SetActive(false);
        _menuButton.gameObject.SetActive(false);
        _restartMenu.SetActive(true);
        Time.timeScale = 0;
        _scoreText.text = _scoreBank.Score.ToString();       
    }

    private void SoundEnable()
    {
        if(_soundImage.sprite == _soundEnable)
        {
            _soundImage.sprite = _soundDisable;
            AudioListener.volume = 0f;
        }
        else
        {
            _soundImage.sprite = _soundEnable;
            AudioListener.volume = 1f;
        }
    }

    private void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
