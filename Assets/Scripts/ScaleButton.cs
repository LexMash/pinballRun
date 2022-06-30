using UnityEngine;

public class ScaleButton : MonoBehaviour
{
    private void Update()
    {        
        float value = Mathf.Sin(Time.unscaledTime * 2 * 3.14f) * 0.1f + 1f;
        transform.localScale = new Vector3(value, value, 1);
    }
}
