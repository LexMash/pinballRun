using UnityEngine;

public class BallRollingSound : MonoBehaviour
{
    [SerializeField] private Rigidbody _ballRigidbody;
    [SerializeField] private AudioSource _rollingSound;

    private void Start()
    {
        Rolling();
    }

    private void Update()
    {
        if (_ballRigidbody != null)
        {
            _rollingSound.pitch = _ballRigidbody.velocity.magnitude / 5f;
        }
    }

    private void Rolling()
    {
        if (_ballRigidbody != null)
        {
            _rollingSound.loop = true;
            _rollingSound.Play();
        }
    }
}
