 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameOver;
    int p1Score, p2Score;
    float remainingTime = 60.0f;
    public GameObject lemon;
    public TextMeshProUGUI timer, p1Text, p2Text;
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
            timer.transform.position = new Vector2 (Screen.width * 0.5f, Screen.height * 0.5f);
            timer.color = Color.black;
            if (p1Score > p2Score)
            {
                timer.text = "Player 1 Wins!";
            }
            else if (p2Score > p1Score)
            {
                timer.text = "Player 2 Wins!";
            }
            else
            {
                timer.text = "You Tied. Congrats.";
            }
            StartCoroutine("Hesitate");
        }
        else
        {
            timer.text = Mathf.CeilToInt(remainingTime).ToString();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
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

    // Method used to update the scoreboards.
    public void Score(string player)
    {
        if (player == "Jimothy")
        {
            p1Score += 1;
            p1Text.text = p1Score.ToString();
        }
        else if (player == "JimothyPlayer2")
        {
            p2Score += 1;
            p2Text.text = p2Score.ToString();
        }
    }
    IEnumerator Hesitate()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("MainMenu");
    }
}
