using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    private void Awake()
    {
        instance = GetComponent<SpawnManager>();
    }
    public GameObject[] enemyPrefab;
    public float MaxX;
    public float MinX;
    public float Z;
    public float spawnRate = 5f;       
    public float spawnDelay = 1f;    

    private void Start()
    {
        // Start spawning enemies
        InvokeRepeating("SpawnEnemy", spawnDelay, spawnRate);
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab[Random.Range(0,enemyPrefab.Length)], new Vector3(Random.Range(MinX, MaxX), 0f, Z) , Quaternion.Euler(0,-180,0));
    }

    public void StopSpawning()
    {
        CancelInvoke("SpawnEnemy");
    }
}
