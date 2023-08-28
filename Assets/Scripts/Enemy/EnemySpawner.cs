using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyPrefabs; // An array to hold different enemy prefabs to spawn.

    [SerializeField]
    private float minimumSpawnTime; // The minimum time between enemy spawns.

    [SerializeField]
    private float maximumSpawnTime; // The maximum time between enemy spawns.

    private float timeUntilSpawn; // A variable to keep track of the time until the next enemy spawn.

    // Start is called before the first frame update
    void Start()
    {
        SetTimeUntilSpawn(); // Initialize the time until the first spawn.
    }

    private GameObject ChooseEnemy()
    {
        if (enemyPrefabs.Length > 0)
        {
            int randomIndex = Random.Range(0, enemyPrefabs.Length); // Choose a random index from the enemyPrefabs array.
            GameObject selectedPrafab = enemyPrefabs[randomIndex]; // Get the selected enemy prefab.
            return selectedPrafab; // Return the selected enemy prefab.
        }
        else
        {
            Debug.Log("No Loot Dropped"); // Output a message indicating that there are no enemy prefabs to choose from.
            return null; // Return null to indicate no enemy to spawn.
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime; // Decrease the time until the next spawn with each frame.

        if (timeUntilSpawn <= 0)
        {
            Spawn(); // If the time until spawn reaches zero or less, spawn an enemy.
        }
    }

    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime); // Set a random time until the next spawn within the defined range.
    }

    public void Spawn()
    {
        ChooseEnemy(); // Run the Choose Enemy function 
        GameObject chosenPrefab = ChooseEnemy(); // Choose an enemy prefab.
        Instantiate(chosenPrefab, transform.position, Quaternion.identity); // Create an instance of the chosen enemy prefab at the spawner's position with no rotation.
        SetTimeUntilSpawn(); // Set the time until the next spawn.
    }
}