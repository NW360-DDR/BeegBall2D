using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Move : MonoBehaviour
{
    public float speed, jumpPower, brakePower;
    Rigidbody2D rb;
    float xPos;
    bool grounded = true;
    public GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GM.gameOver)
        {
            xPos = Input.GetAxis("P1Move");
            // If we're in the air, we don't want nearly as much control over ourselves as we do on the ground.
            if (!grounded)
            {
                xPos /= 1.3f;
            }
            if (((xPos > 0 && rb.velocity.x < 0) || (xPos < 0 && rb.velocity.x > 0)) && grounded)
            {
                xPos *= brakePower;
            }
            rb.AddForce(Vector2.right * xPos * speed);

            // jumping time
            if (Input.GetButtonDown("P1Jump") && grounded)
            {
                rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                grounded = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 moveDir = (transform.position - collision.transform.position).normalized;
            // Magnitude is used to tell which one is moving at a greater rate, and also conveniently allows us to tell whichever one is moving slower to get the hell away from us.
            if (rb.velocity.magnitude > collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-moveDir * 5, ForceMode2D.Impulse);
            }
            else
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(moveDir * 5, ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            grounded = false;
        }
    }
}
