using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] enemyPrefabs;

    [SerializeField]
    private float minimumSpawnTime;

    [SerializeField]
    private float maximumSpawnTime;

    private float timeUntilSpawn;
    // Start is called before the first frame update
    void Start()
    {
        SetTimeUntilSpawn();
    }

    private GameObject ChooseEnemy()
    {
        if (enemyPrefabs.Length > 0)
        {
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            GameObject selectedPrafab = enemyPrefabs[randomIndex];
            return selectedPrafab;
        }
        else
        {
            Debug.Log("No Loot Dropped");
            return null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;

        if (timeUntilSpawn <= 0)
        {
            ChooseEnemy();
            GameObject chosenPrefab = ChooseEnemy();
            Instantiate(chosenPrefab, transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
        }

    }

    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime);
    }

}
