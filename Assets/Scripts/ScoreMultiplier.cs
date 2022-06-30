using UnityEngine;

public class ScoreMultiplier : MonoBehaviour
{
    [SerializeField] private int _multiplier;
    [SerializeField] private float _time;

    private Collider _collider;
    private void Start()
    {
        _collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ScoreBank scoreBank))
        {
            scoreBank.StartIncreaseScore(_multiplier, _time);

            _collider.enabled = false;
        }
    }
}
