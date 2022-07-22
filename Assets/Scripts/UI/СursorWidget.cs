using UnityEngine;
using UnityEngine.UI;

public class ÑursorWidget : MonoBehaviour
{
    [SerializeField] private Image _leftArrow;
    [SerializeField] private Image _rightArrow;

    private BallMovement _ball;

    private void Awake()
    {
        _leftArrow.gameObject.SetActive(false);
        _rightArrow.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _ball = FindObjectOfType<BallMovement>();
        _ball.ChangeDirection += ChangeSide;
    }
    private void OnDisable()
    {
        _ball.ChangeDirection -= ChangeSide;
    }
    private void ChangeSide(int side)
    {
        _leftArrow.gameObject.SetActive(side < 0);
        _rightArrow.gameObject.SetActive(side > 0);
    }
}
