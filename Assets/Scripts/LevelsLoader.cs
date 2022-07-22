using System.Collections.Generic;
using UnityEngine;

public class LevelsLoader : MonoBehaviour
{
    [SerializeField] private ItemLoader _itemLoader;
    [SerializeField] private GameObject _ball;
    [SerializeField] private LevelsMenu _levelsMenu;
    [SerializeField] private EndGameMenu _endGameMenu;
    [SerializeField] private List<Level> _levels;
    public Level CurrentLevel => _currentLevel;
    private Level _currentLevel;

    private void OnEnable()
    {
        _levelsMenu.LevelChanged += LoadLevel;
        _endGameMenu.NextLevel += NextLevel;
        _endGameMenu.Restart += Restart;
    }

    private void OnDisable()
    {
        _levelsMenu.LevelChanged -= LoadLevel;
        _endGameMenu.NextLevel -= NextLevel;
        _endGameMenu.Restart -= Restart;
    }

    private void Start()
    {
        _currentLevel = FindObjectOfType<Level>();
    }

    private void LoadLevel(int index)
    {
        if(_currentLevel != null)
        {
            if (index != _currentLevel.Index)
            {
                Destroy(_currentLevel.gameObject);
                CreateLevel(index);
            }

            InitializeLevel();
        }
        else
        {
            CreateLevel(index);
            InitializeLevel();
        }
    }

    private void NextLevel()
    {
        LoadLevel(_currentLevel.Index + 1);
    }
    public void Restart()
    {
        LoadLevel(_currentLevel.Index);
    }

    private void CreateLevel(int index)
    {
        Instantiate(_levels[index].gameObject);
        _currentLevel = _levels[index];
    }

    private void InitializeLevel()
    {
        var ball = FindObjectOfType<BallMovement>();
        GameObject ballGO;

        if(ball == null)
        {
            ballGO = Instantiate(_ball, _currentLevel.BallSpawn, Quaternion.identity);
        }
        else
        {
            ballGO = ball.gameObject;           
        }

        ballGO.transform.position = _currentLevel.BallSpawn;
        Camera.main.GetComponent<CameraMove>().SetTarget(ballGO.transform);
    }
}
