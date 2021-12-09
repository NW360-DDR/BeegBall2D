using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SoloManager : MonoBehaviour
{
    public bool gameOver;
    int p1Score;
    float remainingTime = 60.0f;
    public GameObject lemon;
    public TextMeshProUGUI timer, p1Text;
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
            timer.transform.position = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
            timer.color = Color.black;
            timer.text = "Game Over!";
            StartCoroutine("Hesitate");
        }
        else
        {
            timer.text = string.Format("{0, 0:0.0}", remainingTime);
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
            Instantiate(lemon, GetRandomPos(), lemon.transform.rotation);
            yield return new WaitForSeconds(2);
        }
    }
    Vector2 GetRandomPos()
    {
        var x = Random.Range(-11, 11);
        var y = Random.Range(-6, 6);
        return new Vector2(x, y);
    }

    // Method used to update the scoreboards.
    public void Score()
    {
        p1Score++;
        p1Text.text = p1Score.ToString();
    }
    IEnumerator Hesitate()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("MainMenu");
    }
}
