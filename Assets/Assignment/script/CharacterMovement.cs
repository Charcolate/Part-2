using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 destination;
    Vector2 movement;
    public float speed = 3;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        // Movement based on destination
        movement = destination - (Vector2)transform.position;
        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }
        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Obstacle"))
            {
                rb.velocity = Vector2.zero;
                break;
            }
        }

    }
    void Update()
    {
        // Mouse click to set destination
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosScreen = Input.mousePosition;
            Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(mousePosScreen);
            destination = new Vector2(mousePosWorld.x, mousePosWorld.y);
        }

        // Animation based on movement
        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
        }
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Collision detection with walls
        if (collision.CompareTag("Wall"))
        {
            collision.gameObject.SendMessage("YouTouchedTheWall", SendMessageOptions.DontRequireReceiver);
            rb.velocity = Vector2.zero;
        }
    }

}
