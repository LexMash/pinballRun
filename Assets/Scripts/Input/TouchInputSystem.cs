using System;
using UnityEngine;

public class TouchInputSystem : IInputSystem
{
    public event Action Pushed;
    public event Action Dashed;

    private float _swipeOffset = 0.85f;
    private Vector2 firstPressPos;
    private Vector2 secondPressPos;
    private Vector2 swipeDirection;

    private bool _isEnable;
    public bool IsEnable => _isEnable;

    public void Enable()
    {
        _isEnable = true;
    }
    public void Disable()
    {
        _isEnable = false;
    }
    public void Push()
    {
        if (_isEnable)
        {
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                Pushed?.Invoke();
            }

            //for test
            if (Input.GetMouseButtonDown(0))
            {
                Pushed?.Invoke();
            }
        }
    }
    public void Dash()
    {
        if (_isEnable)
        {
            //for test
            if (Input.GetMouseButtonDown(1))
            {
                Dashed?.Invoke();
            }

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
                        Dashed?.Invoke();
                    }
                }
            }
        }
    }
}
