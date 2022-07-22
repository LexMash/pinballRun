using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Transform _ballSpawn;
    [SerializeField] private int _index;
    public Vector3 BallSpawn => _ballSpawn.position;
    public int Index => _index;
}
