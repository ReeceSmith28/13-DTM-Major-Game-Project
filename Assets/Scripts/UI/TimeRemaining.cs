using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeRemaining : MonoBehaviour
{
    public Text textValue; // Reference to the UI Text component
    public WaveCounter waveCounter; // Reference to the WaveCounter script

    // Start is called before the first frame update
    void Start()
    {
        // Make sure you have assigned the UI Text component and WaveCounter script in the Inspector.
        if (textValue == null)
        {
            Debug.LogError("UI Text component not assigned in the Inspector.");
        }

        if (waveCounter == null)
        {
            Debug.LogError("WaveCounter script not assigned in the Inspector.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (textValue != null && waveCounter != null)
        {
            // Update the UI Text with the remaining time from WaveCounter
            textValue.text = waveCounter.timeRemaining.ToString("F2"); // Format the time as desired
        }
    }
}