using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float speed = 0.1f;
        float moveX = 0, moveY = 0;
        if (Input.GetKey(KeyCode.W)) {
            moveY = 1;
        } else if (Input.GetKey(KeyCode.S)) {
            moveY = -1;
        }
        if (Input.GetKey(KeyCode.D)) {
            moveX = 1;
        } else if (Input.GetKey(KeyCode.A)) {
            moveX = -1;
        }
        if (Input.GetKey(KeyCode.RightShift)) {
            speed = 0.25f;
        } else {
            speed = 0.1f;
        }
        Vector3 moveDir = new Vector3(moveX, moveY).normalized;
        rb.MovePosition(transform.position + moveDir * speed);

    }
}
