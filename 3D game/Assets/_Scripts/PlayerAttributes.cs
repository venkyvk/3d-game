using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerAttributes : MonoBehaviour {
    
    public GameObject Player;
    
    public int health, damageCount;
    int currentHealth;
    bool playerFighting;
    public Text healthBar;
    float timer;
    public float originx, originy, originz; 
	
    // Use this for initialization
	void Start () {
        currentHealth = health;
        healthBar.text = "Health " + currentHealth + " / 100";
	}
	
	// Update is called once per frame
	void Update () {
        //Cursor.visible = false;
        if (!playerFighting)
        {
            if (currentHealth != 100)
            {
                timer += Time.deltaTime;
                if (timer == 4.0f)
                {
                    currentHealth += 10;
                    healthBar.text = "Health " + currentHealth + " / 100";
                    timer = 0f;
                }
            }
            else
            {
                if (currentHealth <= 0)
                {
                    Player.transform.position = new Vector3(originx,originy,originz);
                }
            }
        }

	}

    public void ApplyDamage(int damage)
    {
        damageCount += damage;
        if (damageCount == 50)
        {
            currentHealth -= 10;
            healthBar.text = "Health " + currentHealth + " / 100";
            damageCount = 0;
        }
    }

    public void playerInCombat(int combat)
    {
        if (combat == 1)
        {
            playerFighting = true;
        }
        else
        {
            playerFighting = false;
        }
    }
}
