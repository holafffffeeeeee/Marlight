
  using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    // Reference to the fill images of the bars
    public Image healthBar;
    public Image manaBar;
    public Image staminaBar;

    // This function updates the health bar based on the current and maximum health
    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        healthBar.fillAmount = currentHealth / maxHealth;  // Set fill based on percentage
    }

    // This function updates the mana bar based on current and maximum mana
    public void UpdateManaBar(float currentMana, float maxMana)
    {
        manaBar.fillAmount = currentMana / maxMana;
    }

    // This function updates the stamina bar based on current and maximum stamina
    public void UpdateStaminaBar(float currentStamina, float maxStamina)
    {
        staminaBar.fillAmount = currentStamina / maxStamina;
    }
}



