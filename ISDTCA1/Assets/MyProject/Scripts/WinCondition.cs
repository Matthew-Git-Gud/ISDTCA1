using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public void Start()
    {
        Time.timeScale = 1f;
        PlayAllAudio();
    }

    public GameObject WinPanelEscaped;
    public GameObject WinPanelFire;
    public GameObject[] Fire;
    private AudioSource[] allAudioSources;

    void OnTriggerEnter(Collider collider)
    {
        // Checks if object it collides with is a player

        if (collider.gameObject.tag == "Door")
        {
            StartCoroutine(EscapeWin());
        }
    }

    IEnumerator EscapeWin()
    {
        yield return new WaitForSecondsRealtime(1);
        WinPanelEscaped.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        StopAllAudio();
    }

    IEnumerator FireWin()
    {
        yield return new WaitForSecondsRealtime(1);
        WinPanelFire.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        StopAllAudio();
    }

    void PlayAllAudio() {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach( AudioSource audioS in allAudioSources) {
            audioS.Play();
        }
    }

    void StopAllAudio() {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach( AudioSource audioS in allAudioSources) {
            audioS.Stop();
        }
    }

    void Update()
    {
        Fire = GameObject.FindGameObjectsWithTag("Enemy"); // Checks if there are still fire in the building
        Debug.Log(Fire.Length/2 + "Fire Remaining");
        if (Fire.Length == 0)
        {
            StartCoroutine(FireWin());
        }
    }
}
