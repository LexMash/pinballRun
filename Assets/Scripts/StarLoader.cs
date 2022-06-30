using UnityEngine;

public class StarLoader : MonoBehaviour
{
    [SerializeField] private float _loadDistance = 20;

    private Vector3[] _starPosition;
    private Transform _playerPosition;
    private GameObject[] _starsGO;
    private float _currentDistance;

    private void Awake()
    {
        _playerPosition = FindObjectOfType<BallMovement>().transform;

        var _stars = FindObjectsOfType<Star>();

        _starsGO = new GameObject[_stars.Length];

        for (int i = 0; i < _stars.Length; i++)
        {
            _starsGO[i] = _stars[i].gameObject;
        }

        _starPosition = new Vector3[_stars.Length];

        for (int i = 0; i < _stars.Length; i++)
        {
            _starPosition[i] = _starsGO[i].transform.position;
        }
        
        for (int i = 0; i < _starsGO.Length; i++)
        {
            _starsGO[i].SetActive(false);
        }
    }

    private void Update()
    {
        if(_playerPosition != null)
        {
            Load();
        }
    }

    private void Load()
    {
        for (int i = 0; i < _starsGO.Length; i++)
        {
            if (_starsGO[i] != null)
            {
                _currentDistance = Mathf.Abs(_playerPosition.position.z - _starPosition[i].z);

                if (!_starsGO[i].activeSelf)
                {
                    if (_currentDistance <= _loadDistance)
                    {
                        _starsGO[i].SetActive(true);
                    }
                }
                else if (_currentDistance > _loadDistance)
                {
                    _starsGO[i].SetActive(false);
                }
            }
        }
    }
}
