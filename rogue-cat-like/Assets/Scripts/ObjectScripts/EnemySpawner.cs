using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(GameObject)), RequireComponent(typeof(Tilemap))]
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Tilemap tilemap;
    [SerializeField] float spawnInterval = 5.0f;
    Bounds tilemapBounds;
    private void Start()
    {
        StartCoroutine(SpawnEnemies());
        tilemapBounds = tilemap.localBounds;
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            
            float x = Random.Range(tilemapBounds.min.x, tilemapBounds.max.x);
            float y = Random.Range(tilemapBounds.min.y, tilemapBounds.max.y);
            Vector3 spawnPosition = new Vector3(x, y, 0);

            Vector3 viewportPosition = Camera.main.WorldToViewportPoint(spawnPosition);
            if (viewportPosition.x >= 0 && viewportPosition.x <= 1 && viewportPosition.y >= 0 && viewportPosition.y <= 1)
            {
                spawnPosition.x += Camera.main.orthographicSize * Screen.width / Screen.height;
            }
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }

    public float SpawnInterval
    {
        get => spawnInterval;
        set
        {
            spawnInterval = value;
        }
    }
}