using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
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

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //play take damage animation

        if (currentHealth <= 0)
        {
            //play death animation
            Debug.Log("you are dead");

            //go to game over screen
            SceneManager.LoadScene("GameOver");
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<MovePlayer>().enabled = false;

        }
    }

}