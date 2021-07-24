using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    public Transform attackPoint;
    public float attackRange = 1f;
    public LayerMask enemyLayers;
    private int attackDamage = 20;
    private float lastMovementX;
    public bool speedup;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        speedup = false;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.x != 0)
        {
            lastMovementX = movement.x;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            attack();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float speed = 0.1f;
        float moveX = 0, moveY = 0;
        if (Input.GetKey(KeyCode.W))
        {
            moveY = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveY = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveX = -1;
        }
        if (Input.GetKey(KeyCode.RightShift) && speedup)
        {
            speed = 0.25f;
        }
        else
        {
            speed = 0.1f;
        }

        Vector3 moveDir = new Vector3(moveX, moveY).normalized;
        rb.MovePosition(transform.position + moveDir * speed);

    }

    void attack()
    {
        Debug.Log("Attack1");
        if (lastMovementX > 0)
        {
            attackPoint.position = transform.position + new Vector3(0.2f, 0);
            animator.Play("attack");
        }
        else
        {
            attackPoint.position = transform.position + new Vector3(-0.2f, 0);
            animator.Play("attackleft");
        }

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("hit " + enemy.name);
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }

    /*private void OnDrawGizmosSelected() {
        if (attackPoint != null) {
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }*/
}