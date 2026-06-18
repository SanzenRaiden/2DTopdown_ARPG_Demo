using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    //public int currentHealth;
    //public int maxHealth;

    public TMP_Text healthText;
    public Animator healthTextAnim;

    public GameObject damageNumber;

    public Transform player;

    private void Start()
    {
        healthText.text = "HP:" + StatsManager.Instance.currentHealth + "/" + StatsManager.Instance.maxHealth;
        
    }

    public void ChangeHealth(int health)
    {
        StatsManager.Instance.currentHealth += health;
        healthTextAnim.Play("TextUpdate");

        GameObject damage = Instantiate(damageNumber, player.position, default);
        damage.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = health.ToString();
        

        healthText.text = "HP:" + StatsManager.Instance.currentHealth + "/" + StatsManager.Instance.maxHealth;

        if (StatsManager.Instance.currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
