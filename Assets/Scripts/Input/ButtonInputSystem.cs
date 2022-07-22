using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInputSystem : MonoBehaviour, IInputSystem
{
    [SerializeField] private GameObject _inputPanel;
    [SerializeField] private Button _pushButton;
    [SerializeField] private Button _dashButton;

    public event Action Pushed;
    public event Action Dashed;

    public bool IsEnable => _inputPanel.gameObject.activeSelf;

    private void OnEnable()
    {
        _pushButton.onClick.AddListener(Push);
        _dashButton.onClick.AddListener(Dash);
    }
    private void OnDisable()
    {
        _pushButton.onClick.RemoveListener(Push);
        _dashButton.onClick.RemoveListener(Dash);
    }

    public void Push()
    {
        Pushed?.Invoke();
    }
    public void Dash()
    {
        Dashed?.Invoke();
    }

    public void Enable()
    {
        _inputPanel.gameObject.SetActive(true);
    }

    public void Disable()
    {
        _inputPanel.gameObject.SetActive(false);
    }
}
