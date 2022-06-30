using UnityEngine;

public class GravityTrigger : MonoBehaviour
{
    [SerializeField] private Transform _dieTrigger;
    [SerializeField] private float _gravityForce = 5f;
    [SerializeField] private AudioSource _sound;

    private void OnTriggerEnter(Collider other)
    {
        _sound.Play();
    }

    private void OnTriggerStay(Collider other)
    {
        var ball = other.GetComponent<Rigidbody>();

        var direction = _dieTrigger.position - ball.transform.position;
        direction.Normalize();

        if (ball)
        {
            ball.AddForce(direction * _gravityForce, ForceMode.Force);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _sound.Stop();
    }
}
