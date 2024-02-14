using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float health;
    public float currentHealth;

    public Slider slider;

    void Start()
    {
        
    }

    public void TakeDamage(float damage)
    {
        slider.value -= damage;
        PlayerPrefs.SetFloat("Health", slider.value);
        PlayerPrefs.Save();
    }

    public void CheckHealth()
    {
        slider.value = PlayerPrefs.GetFloat("Health", slider.value);
    }
}
