using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TTManager : MonoBehaviour
{
    public bool gameOver;
    int p1Score = -1;
    float elapsed = 0.0f;
    public GameObject lemon;
    public TextMeshProUGUI timer, p1Text;
    // Start is called before the first frame update
    void Start()
    {
        LemonTime();

    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        timer.text = string.Format("{0, 0:0.00}", elapsed);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void LemonTime()
    {
        Score();
        if (p1Score < 20)
        {
            Instantiate(lemon, GetRandomPos(), lemon.transform.rotation);
        }
        else
        {
            gameOver = true;
            p1Text.transform.position = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
            p1Text.text = "Nicely Done!";
            StartCoroutine("Hesitate");
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
