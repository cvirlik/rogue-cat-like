using UnityEngine;

public class SceneController : MonoBehaviour
{
    private EnemySpawner enemySpawner;

    void Start()
    {
        EnemySpawner enemySpawnerGameObject = (EnemySpawner)FindAnyObjectByType(typeof(EnemySpawner));
        if (enemySpawnerGameObject != null)
        {
            enemySpawner = enemySpawnerGameObject;
        }
        else
        {
            Debug.LogError("Spawner GameObject not found");
        }
    }

    public void SpeedUpSpawn(){
        enemySpawner.SpawnInterval += 0.1f;
    }
}
