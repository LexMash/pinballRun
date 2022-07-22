using System.Collections;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class BallMovement : MonoBehaviour
{
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _maxStrafeSpeed;
    [SerializeField] private float _normalizeSpeed;

    [SerializeField] private float _dashDistance;
    [SerializeField] private float _dashTime;
    [SerializeField] private float _dashingTime;
    [SerializeField] private float _dashCoolDownTime;
    [SerializeField] private ChargeIndicator _chargeIndicator;
    [SerializeField] private InputHandler _inputHandler;

    public event Action<int> ChangeDirection;
    public event Action OnDied;
    public event Action PlayPushSound;
    public event Action<float,float> DashCharging;

    private bool _canDash;
    private float _dashTimer;

    private Rigidbody _rigidBody;
    private int _currentDirection;

    private void OnEnable()
    {
        _inputHandler.InputSystem.Pushed += Pushed;
        _inputHandler.InputSystem.Dashed += Dashed;
    }

    private void OnDisable()
    {
        OnDied?.Invoke();
        _inputHandler.InputSystem.Pushed -= Pushed;
        _inputHandler.InputSystem.Dashed -= Dashed;
    }
    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.maxAngularVelocity = 20f;

        var dirArr = new int[] { -1, 1, 2 };
        _currentDirection = dirArr[Random.Range(0, 2)];
        ChangeDirection?.Invoke(_currentDirection);
        _rigidBody.AddForce(Vector3.right * _currentDirection * 3f, ForceMode.Impulse);

        _canDash = true;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Pushed()
    {
        ChangeDirection?.Invoke(_currentDirection);
        PlayPushSound?.Invoke();
        Push();
    }
    private void Dashed()
    {
        DashBehavior();
    }

    private void Move()
    {
        _rigidBody.AddForce(Vector3.forward * _forwardSpeed, ForceMode.VelocityChange);
    }
    private void Push()
    {
        _currentDirection *= -1;
        _rigidBody.AddForce(Vector3.right * _currentDirection * _maxStrafeSpeed, ForceMode.Impulse);
    }

    private void DashBehavior()
    {
        if (_canDash)
        {
            _dashTimer = 0;
            StartCoroutine(Dash());       
        }
    }
    private IEnumerator Dash()
    {
        _canDash = false;

        WaitForSeconds dashTime = new WaitForSeconds(_dashingTime);
        WaitForSeconds dashCoolDown = new WaitForSeconds(_dashCoolDownTime);

        var dashPower = _dashDistance / _dashTime;
        _rigidBody.AddForce(Vector3.forward * dashPower, ForceMode.Impulse);

        while (_dashTimer < _dashCoolDownTime)
        {
            _dashTimer += Time.deltaTime;
            DashCharging?.Invoke(_dashTimer, _dashCoolDownTime);
            yield return null;
        }
        _canDash = true;
        yield break;
    }
}
