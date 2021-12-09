using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonTT : MonoBehaviour
{
    private TTManager GM;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("TTManager").GetComponent<TTManager>();
    }



    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            transform.position = GetRandomPos();
        }
        else
        {
            GM.LemonTime();
            Destroy(gameObject);
        }
    }

    Vector2 GetRandomPos()
    {
        var x = Random.Range(-11, 11);
        var y = Random.Range(-6, 6);
        return new Vector2(x, y);
    }
}