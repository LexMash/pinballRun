using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField] private FlyToScore _flyToScore;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BallCollision>())
        {
            _flyToScore.enabled = true;
        }
    }
}
