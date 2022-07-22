using UnityEngine;
using UnityEngine.UI;

public class InGameUI : Window
{
    [SerializeField] private Button _pauseBtn;

    private void OnEnable()
    {
        _pauseBtn.onClick.AddListener(delegate { NextWindow(typeof(PauseMenu)); });
    }
    private void OnDisable()
    {
        _pauseBtn.onClick.RemoveListener(delegate { NextWindow(typeof(PauseMenu)); });
    }
}