using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectSmoke : MonoBehaviour
{
    public Slider healthbar;
    Animator anim;
    public string opponent;
    public GameObject Collider;
    bool TakeDamage = true;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != opponent) return;

        if (TakeDamage)
        {
            StartCoroutine(WaitForSeconds());
            healthbar.value -= 20;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    IEnumerator WaitForSeconds()
    {
        TakeDamage = false;
        yield return new WaitForSecondsRealtime(1);
        TakeDamage = true;
    }
}
