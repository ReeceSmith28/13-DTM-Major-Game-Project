using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Boss;
    public void Spawn()
    {
        Instantiate(Boss, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
