using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedGate : MonoBehaviour
{
    public float Power = 1.01f;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var rb = other.GetComponent<Rigidbody2D>() as Rigidbody2D;
            rb.velocity *= Power;
        }
    }
}
