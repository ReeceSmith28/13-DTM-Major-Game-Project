using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveCounter : MonoBehaviour
{
    public float timeRemaining;
    public UnityEvent startBoss;

    private void Start()
    {
    }

    public void Update()
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <=0)
        {
            timeRemaining = timeRemaining = 0;
        }
        if (timeRemaining == 0)
        {
            StartBossFight();
        }
    }

    public void StartBossFight()
    {
        startBoss.Invoke();
    }

}
