using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed, jumpPower, brakePower;
    Rigidbody2D rb;
    float xPos;
    bool grounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Time to check for braking power on the X Axis of movement.
        xPos = Input.GetAxis("Horizontal");
        if ((xPos > 0 && rb.velocity.x < 0) || (xPos < 0 && rb.velocity.x > 0))
        {
            xPos *= brakePower;
        }

        rb.AddForce(Vector2.right * xPos * speed);

        // jumping time
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            grounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            grounded = true;
        }
    }
}
