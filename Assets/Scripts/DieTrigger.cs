using UnityEngine;

public class DieTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            Destroy(other.gameObject);
        }
    }

}
