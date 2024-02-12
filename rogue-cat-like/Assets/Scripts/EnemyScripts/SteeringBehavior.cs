using UnityEngine;

public class SteeringBehavior : MonoBehaviour
{
    private Transform Player;
    [SerializeField] float Speed = 2.0f;

    void Start()
    {
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        if (playerGameObject != null)
        {
            Player = playerGameObject.transform;
        }
        else
        {
            Debug.LogError("Player GameObject not found");
        }
    }

    void Update()
    {
        if (Player != null)
        {
            Vector3 direction = Player.position - transform.position;
            direction.Normalize();
            transform.position += direction * Speed * Time.deltaTime;
        }
    }
}
