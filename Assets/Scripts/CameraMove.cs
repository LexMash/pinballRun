using UnityEngine;

[ExecuteAlways]
public class CameraMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _offset;

    private Transform _playerTransform;
    private Vector3 _target;

    private void Start()
    {
        _playerTransform = FindObjectOfType<BallMovement>().transform;
    }

    private void LateUpdate()
    {
        if(_playerTransform != null)
        {
            _target = new Vector3(transform.position.x, transform.position.y, _playerTransform.position.z + _offset);

            transform.position = Vector3.Lerp(transform.position, _target, _speed * Time.deltaTime);
        }
    }
}
