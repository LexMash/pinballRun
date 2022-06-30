using UnityEngine;
using UnityEngine.UI;

public class BoardWidget : MonoBehaviour
{
    [SerializeField] private BallMovement _ball;
    [SerializeField] private Image _leftBorder;
    [SerializeField] private Image _rightBorder;

    private void Awake()
    {
        _leftBorder.gameObject.SetActive(false);
        _rightBorder.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _ball.ChangeSide += ChangeSide;
    }
    private void OnDisable()
    {
        _ball.ChangeSide -= ChangeSide;
    }

    private void ChangeSide(int side)
    {
        _leftBorder.gameObject.SetActive(side < 0);
        _rightBorder.gameObject.SetActive(side > 0);
    }
}
