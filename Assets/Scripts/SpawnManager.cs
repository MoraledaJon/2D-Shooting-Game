using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _enemy;
    [SerializeField]
    private float _spawnTime;

    public static SpawnManager Instance;
    private bool shouldSpawn = false;

    private Coroutine spawnCoroutine;

    // Reference to the main camera
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        StartCoroutine(SpawnEnemy());
    }

    private void Awake()
    {
        Instance = this;
    }

    public void Spawn(bool spawn)
    {
        shouldSpawn = spawn;
        if (shouldSpawn && spawnCoroutine == null)
        {
            // If shouldSpawn is true and the coroutine isn't already running, start it
            spawnCoroutine = StartCoroutine(SpawnEnemy());
        }
    }


    private IEnumerator SpawnEnemy()
    {
        while (shouldSpawn)
        {
            GameObject enemy = Instantiate(_enemy[Random.Range(0, _enemy.Length)]);

            float minY = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
            float maxY = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

            enemy.transform.position = new Vector2(transform.position.x, Random.Range(minY, maxY));

            yield return new WaitForSeconds(_spawnTime);
        }
        spawnCoroutine = null;
    }
}
