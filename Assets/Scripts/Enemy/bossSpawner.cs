using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Boss; // Get the Boss prefab to instantiate
    
    // A function that is called when the wave counter timer is at 0
    public void Spawn()
    {
        Instantiate(Boss, transform.position, Quaternion.identity); // Spawns the boss at the position of the spawner
        Destroy(gameObject); // Destroys itself
    }
}
