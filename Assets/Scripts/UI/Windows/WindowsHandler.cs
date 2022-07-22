using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;

public class WindowsHandler : MonoBehaviour
{
    [SerializeField] private List<Window> _windows;

    public IReadOnlyList<Window> Windows => _windows;

    private Stack<Window> _windowsStack;
    private Window _currentWindow;

    private void Awake()
    {
        _windowsStack = new Stack<Window>();
    }

    private void OnEnable()
    {
        foreach (var window in _windows)
        {
            window.Next += ShowNext;
            window.Previous += ShowPrevious;
            window.Hide();
        }
    }

    private void OnDisable()
    {
        foreach (var window in _windows)
        {
            window.Next -= ShowNext;
            window.Previous -= ShowPrevious;
        }
    }

    private void Start()
    {
        ShowNext(typeof(MainMenu));
    }

    private void ShowNext(Type type)
    {
        var window = _windows.FirstOrDefault(w => w.GetType() == type);

        if (_currentWindow)
        {
            _windowsStack.Push(_currentWindow);
            _currentWindow.Hide();
        }
        _currentWindow = window;
        _currentWindow.Show();
    }

    private void ShowPrevious()
    {
        _currentWindow.Hide();
        _currentWindow = _windowsStack.Pop();
        _currentWindow.Show();
    }
}
