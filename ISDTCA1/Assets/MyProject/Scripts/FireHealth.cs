using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireHealth : MonoBehaviour
{
    public int health;
    public int maxhealth = 100;

    public GameObject healthBarUI;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth;
        slider.value = CalculateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = CalculateHealth();
        if(health < maxhealth)
        {
            healthBarUI.SetActive(true);
        }

        if(health <= 0)
        {
            Destroy(gameObject);
        }

        if(health > maxhealth)
        {
            health = maxhealth;
        }
    }

    void OnTriggerStay(Collider collider)
    {

        if (collider.gameObject.tag == "Extinguisher")
        {
            health -= 5;
        }
    }

    float CalculateHealth()
    {
        return health/maxhealth;
    }
}
