using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JimothySolo : MonoBehaviour
{
    public float speed, jumpPower, brakePower;
    Rigidbody2D rb;
    float xPos;
    bool grounded = true;
    public SoloManager GM;

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
            if (Input.GetButtonDown("P2Jump") && grounded)
            {
                rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                grounded = false;
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
