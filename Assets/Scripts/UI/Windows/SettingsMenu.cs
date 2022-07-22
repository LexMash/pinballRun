using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : Window
{
    [SerializeField] private Sprite _soundEnable;
    [SerializeField] private Sprite _soundDisable;
    [SerializeField] private Image _soundImage;
    [SerializeField] private Button _soundBtn;

    //TODO
    //[SerializeField] private Sprite _vibrationEnable;
    //[SerializeField] private Sprite _vibrationDisable;
    //[SerializeField] private Image _vibrationImage;
    //[SerializeField] private Button _vibrationBtn;

    [SerializeField] private Button _backBtn;

    public event Action SoundSwitch;
    //public event Action VibrationSwitch;

    private void OnEnable()
    {
        _soundBtn.onClick.AddListener(SwitchSoundIcon);
        _backBtn.onClick.AddListener(PreviousWindow);
    }
    private void OnDisable()
    {
        _soundBtn.onClick.RemoveListener(SwitchSoundIcon);
        _backBtn.onClick.RemoveListener(PreviousWindow);
    }

    private void SwitchSoundIcon()
    {
        _soundImage.sprite = _soundImage.sprite == _soundEnable ? _soundDisable : _soundEnable;
        SoundSwitch?.Invoke();
    }

    //TODO
    //private void SwitchVibrationIcon()
    //{
    //    _vibrationImage.sprite = _soundImage.sprite == _vibrationEnable ? _vibrationDisable : _vibrationEnable;
    //    SoundSwitch?.Invoke();
    //}
}
