using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool gameOver;
    int p1Score, p2Score;
    float remainingTime = 60.0f;
    public GameObject lemon;
    public TextMeshProUGUI timer;
    int lemoncount;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LemonTime");

    }

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0)
        {
            gameOver = true;
        }
        else
        {
            timer.text = Mathf.CeilToInt(remainingTime).ToString();
        }
    }

    IEnumerator LemonTime()
    {
        while (remainingTime > 0)
        {
            lemoncount++;
            Instantiate(lemon, GetRandomPos(), lemon.transform.rotation);
            yield return new WaitForSeconds(2);
        }
    }
    Vector2 GetRandomPos()
    {
        var x = Random.Range(-11, 11);
        var y = Random.Range(-6, 6);
        return new Vector2(x,y);
    }
}
