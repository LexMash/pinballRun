using UnityEngine;

[ExecuteAlways]
public class Follow : MonoBehaviour
{
    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = FindObjectOfType<BallMovement>().transform;
    }

    private void LateUpdate()
    {
        if (_playerTransform != null)
        {
            transform.position = _playerTransform.position;
        }
    }
}
