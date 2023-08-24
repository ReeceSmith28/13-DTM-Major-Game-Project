using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveCounter : MonoBehaviour
{
    public int remainingEnemies;
    public UnityEvent waveComplete;
    public GameObject[] Enemy;

    private void Start()
    {
    }

    public void WaveDecrease(int enemiesKilled)
    {
        remainingEnemies -= enemiesKilled;

        if (remainingEnemies == 0)
        {
            waveComplete.Invoke();
            Enemy = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var enemyObject in Enemy)
            {
                enemyObject.GetComponent<EnemyHealth>().Die();
            }

        }
        if (remainingEnemies < 0)
        {
            remainingEnemies = 0;
        }

    }



}
