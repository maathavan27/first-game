using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 0.1f;
        Vector3 playerPos = player.transform.position;
        Vector3 thisPos = transform.position;

        float diffX = playerPos[0] - thisPos[0]; //+ = right of enemy
        float diffY = playerPos[1] - thisPos[1]; //+ = top of enemy
        float moveX = 0, moveY = 0;
        if (diffX > 0)
        {
            moveX = 1;
        }
        else if (diffX < 0)
        {
            moveX = -1;
        }
        if (diffY > 0)
        {
            moveY = 1;
        }
        else if (diffY < 0)
        {
            moveY = -1;
        }
        Vector3 moveDir = new Vector3(moveX, moveY).normalized;
        rb.MovePosition(transform.position + moveDir * speed);
    }
}