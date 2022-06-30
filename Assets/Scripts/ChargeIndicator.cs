using UnityEngine;
using UnityEngine.UI;


public class ChargeIndicator : MonoBehaviour
{
    [SerializeField] private Image _indicatorImage;

    public void ActionStart(float currentCharge, float maxCharge)
    {
        _indicatorImage.fillAmount = currentCharge / maxCharge;
    }

}
