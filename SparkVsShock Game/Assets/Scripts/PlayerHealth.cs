using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public static int health;
    public int currentHealth;
    [SerializeField] private Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    private void Update()
    {
        currentHealth = health;
        healthText.text = health.ToString();
    }
}
