using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;

        //play hurt animation

        if (currentHealth <= 0) {
            death();
        }

    }

    public void death() {
        //play death animation

        Debug.Log("dead");

        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<MoveEnemy>().enabled = false;
        this.enabled = false;
    }
}
