using UnityEngine;

[RequireComponent(typeof(Transform))]
public class CameraController : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Transform cameraTransform;
    public float smoothing = 5f;

    Vector3 offset;

    void Start()
    {
        offset = cameraTransform.position - playerTransform.position;
    }

    void FixedUpdate()
    {
        Vector3 targetCamPos = playerTransform.position + offset;
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, targetCamPos, smoothing * Time.fixedDeltaTime);
    }
}