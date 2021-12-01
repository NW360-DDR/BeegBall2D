using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameOver;
    int p1Score, p2Score;
    float remainingTime = 60.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;
    }
}
