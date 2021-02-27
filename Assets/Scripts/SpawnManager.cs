using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject enemyContainer;
    [SerializeField] private float timeToSpawn = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }
    
    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            var newPosition = new Vector3(Random.Range(-8f, 8f), 7, 0);
            var enemy = Instantiate(enemyPrefab, newPosition, Quaternion.identity);
            enemy.transform.parent = enemyContainer.transform;

            yield return new WaitForSeconds(timeToSpawn);
        }
    }
}