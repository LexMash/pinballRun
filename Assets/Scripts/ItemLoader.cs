using UnityEngine;

public class ItemLoader : MonoBehaviour
{
    [SerializeField] private float _loadDistance = 20;

    private Vector3[] _itemPosition;
    private Transform _playerPosition;
    private GameObject[] _itemsGameObjects;
    private float _currentDistance;

    private void Awake()
    {
        _playerPosition = FindObjectOfType<BallMovement>().transform;
    }
    private void Start()
    {
        InitializeLevelItems();
    }

    private void Update()
    {
        if(_playerPosition != null)
        {
            Load();
        }
    }

    public void InitializeLevelItems()
    {
        var items = FindObjectsOfType<Item>();

        _itemsGameObjects = new GameObject[items.Length];

        for (int i = 0; i < items.Length; i++)
        {
            _itemsGameObjects[i] = items[i].gameObject;
        }

        _itemPosition = new Vector3[items.Length];

        for (int i = 0; i < items.Length; i++)
        {
            _itemPosition[i] = _itemsGameObjects[i].transform.position;
        }

        for (int i = 0; i < _itemsGameObjects.Length; i++)
        {
            _itemsGameObjects[i].SetActive(false);
        }
    }

    private void Load()
    {
        for (int i = 0; i < _itemsGameObjects.Length; i++)
        {
            if (_itemsGameObjects[i] != null)
            {
                _currentDistance = Mathf.Abs(_playerPosition.position.z - _itemPosition[i].z);

                if (!_itemsGameObjects[i].activeSelf)
                {
                    if (_currentDistance <= _loadDistance)
                    {
                        _itemsGameObjects[i].SetActive(true);
                    }
                }
                else if (_currentDistance > _loadDistance)
                {
                    _itemsGameObjects[i].SetActive(false);
                }
            }
        }
    }
}
