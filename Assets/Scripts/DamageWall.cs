using UnityEngine;

public class DamageWall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        var ball = collision.gameObject.GetComponent<BallMovement>();

        if (ball)
        {
            Destroy(collision.gameObject);
        }
    }
}
