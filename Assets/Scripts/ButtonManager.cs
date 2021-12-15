using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject mainMenu, howTo;
    public void LoadLevel(string LevelName)
    {
        SceneManager.LoadScene(LevelName);
    }
    public void QUIT()
    {
        Application.Quit();
    }

    public void HowToPlay()
    {
        mainMenu.SetActive(false);
        howTo.SetActive(true);
    }

    public void BackToMain()
    {
        howTo.SetActive(false);
        mainMenu.SetActive(true);
    }
}
