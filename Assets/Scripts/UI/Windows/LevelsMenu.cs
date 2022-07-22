using UnityEngine;
using UnityEngine.UI;
using System;
public class LevelsMenu : Window
{
    [SerializeField] private Button _backBtn;
    [SerializeField] private Button _levelOne;
    [SerializeField] private Button _levelTwo;

    public event Action<int> LevelChanged;

    private void OnEnable()
    {
        _backBtn.onClick.AddListener(PreviousWindow);

        _levelOne.onClick.AddListener(delegate { ChooseLevel(0); });
        _levelTwo.onClick.AddListener(delegate { ChooseLevel(1); });
    }
    private void OnDisable()
    {
        _backBtn.onClick.RemoveListener(PreviousWindow);

        _levelOne.onClick.RemoveListener(delegate { ChooseLevel(0); });
        _levelTwo.onClick.RemoveListener(delegate { ChooseLevel(1); });
    }

    private void ChooseLevel(int index)
    {
        LevelChanged?.Invoke(index);
        NextWindow(typeof(InGameUI));
    }
}
