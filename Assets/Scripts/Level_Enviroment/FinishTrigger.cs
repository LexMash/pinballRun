using UnityEngine;
using System;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private ParticleSystem _ps1;

    public event Action OnFinish;

    private void Start()
    {
        _ps1.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            OnFinish?.Invoke();
            _ps1.Play();
        }
    }
}
