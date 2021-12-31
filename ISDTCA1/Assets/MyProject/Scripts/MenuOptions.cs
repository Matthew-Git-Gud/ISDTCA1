using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject SettingsPanel;

    public void Start()
    {
        Time.timeScale = 1f;
    }

    public void startgame()
    {
        SceneManager.LoadScene ("Office");
    }

    public void startVRgame()
    {
        SceneManager.LoadScene ("ISDTCA1");
    }

    public void Menu()
    {
        MainPanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }

    public void SettingsMenu()
    {
        MainPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }

    public void quitgame()
    {
        Debug.Log("Quit Button Pressed");
        Application.Quit();
    }
}
