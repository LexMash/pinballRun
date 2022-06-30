using System.Collections;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class BallMovement : MonoBehaviour
{
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _maxStrafeSpeed;
    [SerializeField] private float _minStrafeSpeed;
    [SerializeField] private float _normalizeSpeed;

    [SerializeField] private float _dashDistance;
    [SerializeField] private float _dashTime;
    [SerializeField] private float _dashingTime;
    [SerializeField] private float _dashCoolDownTime;
    [SerializeField] private ChargeIndicator _chargeIndicator;

    [SerializeField] private float _swipeOffset;

    public event Action<int> ChangeSide;
    public event Action OnDied;
    public event Action MakePushSound;

    private bool _isDashing;
    private bool _canDash;
    private float _dashTimer;
    private Coroutine _dashRoutine;

    private Rigidbody _rigidBody;
    private int _currentDirection;

    private Vector2 firstPressPos;
    private Vector2 secondPressPos;
    private Vector2 swipeDirection;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.maxAngularVelocity = 20f;

        var dirArr = new int[] { -1, 1, 2 };
        _currentDirection = dirArr[Random.Range(0, 2)];
        ChangeSide?.Invoke(_currentDirection);
        _rigidBody.AddForce(Vector3.right * _currentDirection * 3f, ForceMode.Impulse);

        _canDash = true;
    }

    private void OnDestroy()
    {
        OnDied?.Invoke();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began))
        {

            Push();
        }

        if (Input.GetMouseButtonDown(1))
        {
            DashBehavior();
        }

        Swipe();

        if (_dashTimer <= _dashCoolDownTime)
        {
            _dashTimer += Time.deltaTime;
            _chargeIndicator.ActionStart(_dashTimer, _dashCoolDownTime);
        }
    }

    private void Swipe()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Began)
            {
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }
            if (t.phase == TouchPhase.Ended)
            {
                secondPressPos = new Vector2(t.position.x, t.position.y);

                swipeDirection = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                swipeDirection.Normalize();

                if (swipeDirection.y > _swipeOffset && (swipeDirection.x > -_swipeOffset || swipeDirection.x < _swipeOffset))
                {
                    DashBehavior();
                }

                if (swipeDirection.y < -_swipeOffset && (swipeDirection.x > -_swipeOffset || swipeDirection.x < _swipeOffset))
                {
                    //timeShift?
                }

            }
        }
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        /*_rigidBody.velocity = new Vector3(_currentStrafeSpeed * _currentDirection, _rigidBody.velocity.y, _forwardSpeed);*/
        /*_rigidBody.velocity = new Vector3(_rigidBody.velocity.x, _rigidBody.velocity.y, _forwardSpeed);*/
        _rigidBody.AddForce(Vector3.forward * _forwardSpeed, ForceMode.VelocityChange);
    }
    private void Push()
    {
        _currentDirection *= -1;
        ChangeSide?.Invoke(_currentDirection);
        MakePushSound?.Invoke();

        _rigidBody.AddForce(Vector3.right * _currentDirection * _maxStrafeSpeed, ForceMode.Impulse);
    }
    private void DashBehavior()
    {
        if (_canDash)
        {
            _dashRoutine = StartCoroutine(Dash());
            _dashTimer = 0;
        }
    }
    private IEnumerator Dash()
    {
        WaitForSeconds dashTime = new WaitForSeconds(_dashingTime);
        WaitForSeconds dashCoolDown = new WaitForSeconds(_dashCoolDownTime);

        _canDash = false;

        var dashPower = _dashDistance / _dashTime;
        _rigidBody.AddForce(Vector3.forward * dashPower, ForceMode.Impulse);

        yield return dashTime;

        yield return dashCoolDown;
        _canDash = true;
        StopDashRoutine();
    }
    private void StopDashRoutine()
    {
        StopCoroutine(_dashRoutine);
    }
}
