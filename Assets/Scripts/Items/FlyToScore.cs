using UnityEngine;

public class FlyToScore : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _rotationSpeed;
    [SerializeField] private float _distance;
    [SerializeField] private float _scaleSpeed;
    [SerializeField] private ParticleSystem _particleSystem;

    private Transform _scoreTransform;

    private void Start()
    {
        _scoreTransform = FindObjectOfType<ScorePoint>().transform;

        _particleSystem.gameObject.SetActive(true);
        _particleSystem.Play();
    }

    private void Update()
    {
        if (transform.localScale.x <= 0.05)
        {
            Destroy(gameObject);
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
