using UnityEngine;
using UnityEngine.UI;

public class ChargeIndicator : MonoBehaviour
{
    [SerializeField] private BallMovement _ballMovement;
    [SerializeField] private Image _indicatorImage;
    private void Start()
    {
        if(_ballMovement == null)
        {
            _ballMovement = FindObjectOfType<BallMovement>();
        }

        _ballMovement.DashCharging += DashCharging;
    }
    private void OnDisable()
    {
        _ballMovement.DashCharging += DashCharging;
    }
    private void DashCharging(float currentCharge, float maxCharge)
    {
        _indicatorImage.fillAmount = currentCharge / maxCharge;
    }
}
