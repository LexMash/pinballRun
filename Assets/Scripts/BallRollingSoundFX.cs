using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BallRollingSoundFX : MonoBehaviour
{
    [SerializeField] private AudioSource _rollingSound;

    private Rigidbody _ball;

    public void SetBall(Rigidbody ball)
    {
        _ball = ball;
        Rolling();
    }

    private void Start()
    {
        _ball = GetComponent<Rigidbody>();
        Rolling();
    }

    private void Update()
    {
        if (_ball != null)
        {
            _rollingSound.pitch = _ball.velocity.magnitude / 5f;
        }
    }

    private void Rolling()
    {
        if (_ball != null)
        {
            _rollingSound.loop = true;
            _rollingSound.Play();
        }
    }

    private void OnDied()
    {
        _rollingSound.Stop();
    }
}
