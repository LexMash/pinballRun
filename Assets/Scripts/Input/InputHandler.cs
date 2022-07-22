using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public IInputSystem InputSystem => _inputSystem;
    private IInputSystem _inputSystem;

    private void Awake()
    {
        SetInputSystem(new TouchInputSystem());
    }
    public void SetInputSystem(IInputSystem inputSystem)
    {
        _inputSystem = inputSystem;
        _inputSystem.Enable();
    }
    private void Update()
    {
        _inputSystem.Push();
        _inputSystem.Dash();
    }
}
