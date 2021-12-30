using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{
    public void retrygame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void quitgame()
    {
        Time.timeScale = 1f;
        Debug.Log("Quit Button Pressed");
        Application.Quit();
    }
}
