using UnityEngine;

public class BouncedWall : MonoBehaviour
{
    [SerializeField] private float _force;
    private void OnCollisionEnter(Collision collision)
    {
        var ball = collision.gameObject.GetComponent<BallMovement>();

        if (ball)
        {
            ball.GetComponent<Rigidbody>().AddForce(-transform.forward * _force, ForceMode.Impulse);
        }
    }
}
