using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : Window
{
    [SerializeField] private Button _playBtn;
    [SerializeField] private Button _chooseLevelBtn;
    [SerializeField] private Button _settingsBtn;

    private void OnEnable()
    {
        _playBtn.onClick.AddListener(delegate { NextWindow(typeof(InGameUI)); });
        _chooseLevelBtn.onClick.AddListener(delegate { NextWindow(typeof(LevelsMenu)); });
        _settingsBtn.onClick.AddListener(delegate { NextWindow(typeof(SettingsMenu)); });
    }
    private void OnDisable()
    {
        _playBtn.onClick.RemoveListener(delegate { NextWindow(typeof(InGameUI)); }) ;
        _chooseLevelBtn.onClick.RemoveListener(delegate { NextWindow(typeof(LevelsMenu)); });
        _settingsBtn.onClick.RemoveListener(delegate { NextWindow(typeof(SettingsMenu)); });
    }
}
