using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lemon : MonoBehaviour
{
    private GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }



    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            transform.position = GetRandomPos();
        }
        else
        {
            GM.Score(other.gameObject.name);
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
