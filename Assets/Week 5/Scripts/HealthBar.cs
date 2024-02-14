using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float maxHealth = 5;
    public float currentHealth;


    public Slider slider;

    void Start()
    {
        currentHealth = maxHealth; 
        UpdateHealthBar(); 
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
    }

    void UpdateHealthBar()
    {
        slider.value = currentHealth;
    }

}
