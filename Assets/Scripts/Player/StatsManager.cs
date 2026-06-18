using UnityEngine;
using TMPro;


public class StatsManager : MonoBehaviour
{
    public static StatsManager Instance;
    public TMP_Text healthText;
    

    [Header("Combat Stats")]
    public float weaponRange = 1;
    public float knockbackForce = 50;
    public float stunTime = 0.3f;
    public float knockbackTime = 0.15f;
    public int damage = 1;
    public float cooldown = 2;

    [Header("Movement Stats")]
    public float speed = 5;

    [Header("Health Stats")]
    public int currentHealth;
    public int maxHealth;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateMaxHealth(int amount)
    {
        maxHealth += amount;
        healthText.text = currentHealth + "/" + maxHealth;
    }
}
