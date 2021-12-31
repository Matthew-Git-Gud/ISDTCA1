using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseCondition : MonoBehaviour
{
    public Slider healthbar;
    public GameObject LosePanel;

    void OnTriggerEnter(Collider collider)
    {
        // Checks if object it collides with is a player

        if (collider.gameObject.tag == "Fire")
        {
            StartCoroutine(WaitForSeconds());
        }

    }

    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSecondsRealtime(0);
        LosePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (healthbar.value <= 0)
        {
            StartCoroutine(WaitForSeconds());
        }
    }
}
