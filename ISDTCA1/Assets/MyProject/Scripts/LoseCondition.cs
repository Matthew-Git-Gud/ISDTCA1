using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseCondition : MonoBehaviour
{
    public Slider healthbar;
    public GameObject LosePanelFire;
    public GameObject LosePanelSmoke;
    private AudioSource[] allAudioSources;

    public void Start()
    {
        Time.timeScale = 1f;
        PlayAllAudio();
    } 

    void OnTriggerEnter(Collider collider)
    {
        // Checks if object it collides with is a player

        if (collider.gameObject.tag == "Fire")
        {
            StartCoroutine(LostFire());
        }

    }

    IEnumerator LostFire()
    {
        yield return new WaitForSecondsRealtime(0);
        LosePanelFire.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        StopAllAudio();
    }

    IEnumerator LostSmoke()
    {
        yield return new WaitForSecondsRealtime(0);
        LosePanelSmoke.SetActive(true);
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
        if (healthbar.value <= 0)
        {
            StartCoroutine(LostSmoke());
        }
    }
}
