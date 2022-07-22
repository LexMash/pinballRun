using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] private Text _score;
    [SerializeField] private ScoreBank _bank;

    private void OnEnable()
    {
        _bank.ScoreCollected += ScoreCollected;
    }

    private void OnDisable()
    {
        _bank.ScoreCollected -= ScoreCollected;
    }

    private void ScoreCollected(int score)
    {
        ShowScore(score);
    }

    private void ShowScore(int score)
    {
        _score.text = score.ToString();
    }
}
