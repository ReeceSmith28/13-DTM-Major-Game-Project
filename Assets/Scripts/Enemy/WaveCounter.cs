using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveCounter : MonoBehaviour
{
    public int remainingEnemies;
    public UnityEvent waveComplete;

    private void Start()
    {
    }

    public void WaveDecrease(int enemiesKilled)
    {
        remainingEnemies -= enemiesKilled;

        if (remainingEnemies == 0)
        {
            waveComplete.Invoke();
        }
    }



}
