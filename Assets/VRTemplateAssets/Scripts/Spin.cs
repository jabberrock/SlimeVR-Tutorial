using UnityEngine;

public class Spin : MonoBehaviour
{
    public void Update()
    {
        this.transform.Rotate(Vector3.up, 10.0f * Time.deltaTime);
    }
}
