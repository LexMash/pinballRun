using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] private Text _score;
    [SerializeField] private ScoreBank _bank;

    private void OnEnable()
    {
        _bank.ScoreChanged += ScoreChanged;
    }

    private void OnDisable()
    {
        _bank.ScoreChanged -= ScoreChanged;
    }

    private void ScoreChanged(int score)
    {
        ShowScore(score);
    }

    private void ShowScore(int score)
    {
        _score.text = score.ToString();
    }
}
