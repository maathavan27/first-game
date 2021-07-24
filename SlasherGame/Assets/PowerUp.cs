using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
 
    }

    void Pickup(Collider2D Player)
    {
        MovePlayer speed = Player.GetComponent<MovePlayer>();
        speed.speedup = true;
    }

}
