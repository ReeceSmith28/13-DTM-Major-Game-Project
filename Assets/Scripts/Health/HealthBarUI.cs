using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image healthBarForegroundImage; // Reference to the UI image representing the health bar foreground.

    // Update the health bar UI based on the given health controller.
    public void UpdateHealthBar(HealthController healthController)
    {
        healthBarForegroundImage.fillAmount = healthController.RemainingHealthPercentage; // Set the fill amount of the health bar foreground to represent the remaining health percentage.
    }
}