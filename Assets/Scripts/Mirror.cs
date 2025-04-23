using UnityEngine;

public class Mirror : MonoBehaviour
{
    public GameObject Target;

    private Plane m_reflect;

    public void Start()
    {
        var mid = (this.transform.position + Target.transform.position) * 0.5f;
        var normal = (Target.transform.position - this.transform.position).normalized;
        m_reflect = new Plane(normal, mid);

        this.transform.localScale =
            new Vector3(-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
    }

    public void Update()
    {
        this.transform.position =
            Target.transform.position -
                2.0f * m_reflect.GetDistanceToPoint(Target.transform.position) * m_reflect.normal;

        this.transform.rotation =
            Quaternion.Inverse(Target.transform.rotation);
    }
}