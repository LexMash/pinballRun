using UnityEngine;

public class Star : Item
{
    [SerializeField] private GameObject _flyStar;

    private MeshRenderer _meshRenderer;
    private Rotate _rotate;
    private Collider _collider;

    private void Start()
    {
        _rotate = GetComponent<Rotate>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _collider = GetComponent<Collider>();

        Enable();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BallCollision>())
        {
            Instantiate(_flyStar, transform.position, Quaternion.identity);
            Disable();
        }
    }

    private void Disable()
    {
        _meshRenderer.enabled = false;
        _rotate.enabled = false;
        _collider.enabled = false;
    }

    private void Enable()
    {
        _meshRenderer.enabled = true;
        _rotate.enabled = true;
        _collider.enabled = true;
    }
}
