using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyThing : MonoBehaviour
{
    public Vector2 bounceDir;
    public float strength;
    // Start is called before the first frame update
    void Start()
    {
        bounceDir = bounceDir.normalized;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
       var otherRB = other.gameObject.GetComponent<Rigidbody2D>() as Rigidbody2D;
        otherRB.AddForce(bounceDir * strength, ForceMode2D.Impulse);
    }
}
