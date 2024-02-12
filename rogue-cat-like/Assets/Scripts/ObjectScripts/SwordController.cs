using UnityEngine;

public class RotateAroundParent : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        if (transform.parent != null)
        {
            transform.RotateAround(transform.parent.position, Vector3.forward, speed * Time.deltaTime);
        }
    }
}