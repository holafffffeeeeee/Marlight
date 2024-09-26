using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    public float maxMana = 50f;
    public float currentMana;

    public float maxStamina = 75f;
    public float currentStamina;

    private HUDManager hudManager;  // Reference to the HUDManager
   
    void Start()
    {
        GameManager gammemanager = FindAnyObjectByType<GameManager>();
        currentHealth = maxHealth;
        currentMana = maxMana;
        currentStamina = maxStamina;
        hudManager = FindObjectOfType<HUDManager>();
        if (!gammemanager.hasSavedStats)
        {
            return;
        }
        else
        {
            GameManager.instance.RestorePlayerStats(this);
        }


        if (hudManager == null)
        {
            Debug.LogError("HUDManager not found in the scene!");
        }
    }

    void Update()
    {
        // For testing, we can press keys to modify health, mana, and stamina

        // Press 'H' to take damage
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10f);
        }

        // Press 'M' to use mana
        if (Input.GetKeyDown(KeyCode.M))
        {
            UseMana(10f);
        }

        // Press 'S' to use stamina
        if (Input.GetKeyDown(KeyCode.S))
        {
            UseStamina(10f);
        }

        // Press 'R' to regenerate health and stamina for testing
        if (Input.GetKeyDown(KeyCode.R))
        {
            RegenerateHealth(10f);
            RegenerateStamina(5f);
        }

        // Update the HUD whenever values change
        UpdateHUD();
    }

    // Example method to take damage
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0) currentHealth = 0;
    }

    // Example method to use mana
    public void UseMana(float amount)
    {
        currentMana -= amount;
        if (currentMana < 0) currentMana = 0;
    }

    // Example method to use stamina
    public void UseStamina(float amount)
    {
        currentStamina -= amount;
        if (currentStamina < 0) currentStamina = 0;
    }

    // Example method to regenerate health
    public void RegenerateHealth(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
    }

    // Example method to regenerate stamina
    public void RegenerateStamina(float amount)
    {
        currentStamina += amount;
        if (currentStamina > maxStamina) currentStamina = maxStamina;
    }

    // This method updates the HUD using the values from the player stats
    void UpdateHUD()
    {
        if (hudManager != null)
        {
              Debug.Log($"Updating HUD - Health: {currentHealth}/{maxHealth}, Mana: {currentMana}/{maxMana}, Stamina: {currentStamina}/{maxStamina}");
            hudManager.UpdateHealthBar(currentHealth, maxHealth);
            hudManager.UpdateManaBar(currentMana, maxMana);
            hudManager.UpdateStaminaBar(currentStamina, maxStamina);
        }
    }
    
}


