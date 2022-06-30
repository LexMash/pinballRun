using UnityEngine;

public class FlyToScore : MonoBehaviour
{
    [SerializeField] private Transform _scoreTransform;
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _rotationSpeed;
    [SerializeField] private GameObject _objectPrefab;
    [SerializeField] private float _distance;
    [SerializeField] private float _scaleSpeed;
    [SerializeField] private ParticleSystem _particleSystem;

    private void Start()
    {
        _particleSystem.gameObject.SetActive(true);
        _particleSystem.Play();
    }

    private void Update()
    {
        if (transform.localScale.x <= 0.05)
        {
            Destroy(_objectPrefab);
        }

        if (Vector3.Distance(transform.position, _scoreTransform.position) <= _distance)
        {
            Scale();
        }

        MoveToTarget();
        Rotate();
    }

    private void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, _scoreTransform.position, _speed * Time.deltaTime);
    }

    private void Rotate()
    {
        transform.Rotate(_rotationSpeed * Time.deltaTime);
    }

    private void Scale()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, _scaleSpeed * Time.deltaTime);
    }
}
