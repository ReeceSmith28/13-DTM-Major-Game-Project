using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagedInvincibility : MonoBehaviour
{

    [SerializeField]
    private float invincibilityDuration;

    private InvincibilityController invincibilityController;

    private void Awake()
    {
        invincibilityController = GetComponent<InvincibilityController>();
    }

    public void StartInvincibilty()
    {
        invincibilityController.StartInvincibility(invincibilityDuration);
    }
}
