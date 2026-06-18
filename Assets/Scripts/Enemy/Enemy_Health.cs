using TMPro;
using UnityEngine;

public class Enemy_Health : MonoBehaviour 
{
    public int expReward = 3;

    public delegate void MonsterDefeated(int exp);
    public static event MonsterDefeated OnMonsterDefeated;

    public int currentHealth;
    public int maxHealth;

    public GameObject damageNumber;
    public Transform enemy;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void ChangeHealth(int health)
    {
        currentHealth += health;

        GameObject damage = Instantiate(damageNumber, enemy.position, default);
        damage.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = health.ToString();

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        else if (currentHealth <= 0)
        {
            OnMonsterDefeated(expReward);
            Destroy(gameObject);
        }
    }

}
