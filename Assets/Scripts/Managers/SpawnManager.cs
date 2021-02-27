using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] public GameObject[] powerUpPrefabs;
    [SerializeField] private GameObject enemyContainer;
    [SerializeField] private float timeToSpawn = 5.0f;

    private bool _canSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
    }

    private IEnumerator SpawnEnemyRoutine()
    {
        while (_canSpawn)
        {
            var newPosition = new Vector3(Random.Range(-8f, 8f), 7, 0);
            var enemy = Instantiate(enemyPrefab, newPosition, Quaternion.identity);
            enemy.transform.parent = enemyContainer.transform;

            yield return new WaitForSeconds(timeToSpawn);
        }
    }

    private IEnumerator SpawnPowerUpRoutine()
    {
        while (_canSpawn)
        {
            var newPosition = new Vector3(Random.Range(-8f, 8f), 7, 0);
            var index = Random.Range(0, powerUpPrefabs.Length);
            Instantiate(powerUpPrefabs[index], newPosition, Quaternion.identity);

            yield return new WaitForSeconds(Random.Range(3.0f, 8.0f));
        }
    }

    public void StopSpawn()
    {
        _canSpawn = false;
    }
}