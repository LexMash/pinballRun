using System;

public interface IInputSystem
{
    public event Action Pushed;
    public event Action Dashed;

    public bool IsEnable { get; }
    public void Push();
    public void Dash();
    public void Enable();
    public void Disable();
}
