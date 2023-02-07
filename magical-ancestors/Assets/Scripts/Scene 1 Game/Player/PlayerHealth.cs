using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerMaxHealth;
    private float playerCurrentHealth;

    [SerializeField] GameEvent OnPlayerDeath;


    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    public void TakeDamage(object data)
    {
        Debug.Log("data");
        if (data is float)
        {
            float amount = (float) data;

            Debug.Log(amount);
            playerCurrentHealth -= amount;

            HandlePlayerDeath();
        }

        else
        {
            Debug.Log("data wasn't a float");
        }
        
    }

    private void HandlePlayerDeath()
    {
        if(playerCurrentHealth <= 0)
        {
            OnPlayerDeath.Raise();
        }
    }
}
