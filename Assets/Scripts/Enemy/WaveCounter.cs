using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveCounter : MonoBehaviour
{
    public float timeRemaining; // The remaining time for the wave countdown.
    public UnityEvent startBoss; // Event to trigger the start of a boss fight.

    // Start is called before the first frame update
    private void Start()
    {
        // This Start function is empty, with no specific initialization code.
    }

    // Update is called once per frame
    public void Update()
    {
        timeRemaining -= Time.deltaTime; // Decrease the time remaining based on real-time.

        // Ensure timeRemaining doesn't go below zero.
        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
        }

        // If the timeRemaining reaches zero, start the boss fight.
        if (timeRemaining == 0)
        {
            StartBossFight();
        }
    }

    // Invoke the startBoss UnityEvent to trigger the boss fight. Spawning the Boss
    public void StartBossFight()
    {
        startBoss.Invoke();
    }
}