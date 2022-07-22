using UnityEngine;
using System;

public class BallCollision : MonoBehaviour
{
    private string _floorTag = "floor";
    public event Action ScoreCollected;
    public event Action Bounced;
    public event Action Damaged;
    public event Action<float> Hited;
    public event Action Multiplied;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != _floorTag)
        {
            var force = collision.impulse.magnitude;
            Hited?.Invoke(force);
        }
        
        if (collision.gameObject.GetComponent<BouncedWall>())
        {
            Bounced?.Invoke();
        }

        if (collision.gameObject.GetComponent<DamageWall>())
        {
            Damaged?.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Star>())
        {
            ScoreCollected?.Invoke();
        }

        if (other.gameObject.GetComponent<ScoreMultiplier>())
        {
            Multiplied?.Invoke();
        }
    }
}
