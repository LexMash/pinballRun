using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : Window
{
    [SerializeField] private Button _mainMenuBtn;
    [SerializeField] private Button _settingsBtn;
    [SerializeField] private Button _restartBtn;
    [SerializeField] private Button _backBtn;

    public event Action Restart;

    private void OnEnable()
    {
        _mainMenuBtn.onClick.AddListener(delegate {NextWindow(typeof(MainMenu)); });
        _settingsBtn.onClick.AddListener(delegate {NextWindow(typeof(SettingsMenu)); });
        _restartBtn.onClick.AddListener(ClickRestart);
        _backBtn.onClick.AddListener(PreviousWindow);
    }
    private void OnDisable()
    {
        _mainMenuBtn.onClick.RemoveListener(delegate { NextWindow(typeof(MainMenu)); });
        _settingsBtn.onClick.RemoveListener(delegate { NextWindow(typeof(SettingsMenu)); });
        _restartBtn.onClick.RemoveListener(ClickRestart);
        _backBtn.onClick.RemoveListener(PreviousWindow);
    }

    private void ClickRestart()
    {
        Restart?.Invoke();
    }
}
