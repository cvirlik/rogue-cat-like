using UnityEngine;

[RequireComponent(typeof(SceneController))]
public class SwordBechavior : MonoBehaviour
{
    private SceneController sceneController;

    void Start()
    {
        SceneController controllerGameObject = (SceneController)FindAnyObjectByType(typeof(SceneController));
        if (controllerGameObject != null)
        {
            sceneController = controllerGameObject;
        }
        else
        {
            Debug.LogError("Controller GameObject not found");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            sceneController.SpeedUpSpawn();
        }
    }
}
