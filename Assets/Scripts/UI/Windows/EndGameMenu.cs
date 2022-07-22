using System;
using UnityEngine;
using UnityEngine.UI;

public class EndGameMenu : Window
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _endGameText;
    [SerializeField] private Button _restartBtn;
    [SerializeField] private Button _nextLevelBtn;
    [SerializeField] private Button _mainMenuBtn;

    public event Action Restart;
    public event Action NextLevel;

    private void OnEnable()
    {
        _restartBtn.onClick.AddListener(ClickRestart);
        _nextLevelBtn.onClick.AddListener(ClickNextLevel);
        _mainMenuBtn.onClick.AddListener(delegate { NextWindow(typeof(MainMenu)); });
    }
    private void OnDisable()
    {
        _restartBtn.onClick.RemoveListener(ClickRestart);
        _nextLevelBtn.onClick.RemoveListener(ClickNextLevel);
        _mainMenuBtn.onClick.RemoveListener(delegate { NextWindow(typeof(MainMenu)); });
    }

    private void Start()
    {
        
    }

    private void ClickRestart()
    {
        Restart?.Invoke();
    }
    private void ClickNextLevel()
    {
        NextLevel?.Invoke();
    }
}
