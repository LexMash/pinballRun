using System;
using UnityEngine;

public abstract class Window: MonoBehaviour
{
    public event Action Showed;
    public event Action Hided;
    public event Action<Type> Next;
    public event Action Previous;
    public void Show()
    {
        gameObject.SetActive(true);
        transform.SetAsLastSibling();
        Showed?.Invoke();
    }

    public void Hide()
    {
        Hided?.Invoke();
        gameObject.SetActive(false);
    }

    protected void NextWindow(Type type)
    {
        Next?.Invoke(type);
    }
    protected void PreviousWindow()
    {
        Previous?.Invoke();
    }
}
