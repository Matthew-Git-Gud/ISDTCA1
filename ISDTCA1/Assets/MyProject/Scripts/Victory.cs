using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public GameObject VictoryPanel;

    void OnTriggerEnter(Collider collider)
    {
        // Checks if object it collides with is a player

        if (collider.gameObject.tag == "Door")
        {
            StartCoroutine(WaitForSeconds());
        }
    }

    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSecondsRealtime(1);
        VictoryPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }
}
