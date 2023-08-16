using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int currHealth;
    public int maxHealth;
    public LogicScript logic;
    public HealthBarScript healthBar;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        currHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void DecreaseHP(int damage)
    {
        if (currHealth > 0)
        {
            currHealth -= damage;
            healthBar.SetHealth(currHealth);
        }else if(currHealth <= 0)
        {
            logic.restartGame();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Goblin"))
        {
            DecreaseHP(1);
            Destroy(collision.gameObject);
        }
    }
}
