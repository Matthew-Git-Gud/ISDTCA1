using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWater : MonoBehaviour
{
    public bool firePulled = false;
    public bool waterPulled = false;
    public void onFireSafetyPinPull()
    {
        Debug.Log("Fire Pulled!");
        firePulled = true;
    }
    public void onWaterSafetyPinPull()
    {
        Debug.Log("Water Pulled!");
        waterPulled = true;
    }
    public void OnShoot()
    {
        if (firePulled == true)
        {
            Instantiate(Resources.Load("Projectile"), transform.position, transform.rotation);
        }
    }
    public void ShootWrong()
    {
        if (waterPulled == true)
        {
            Instantiate(Resources.Load("water"), transform.position, transform.rotation);
        }
    }
    public void HoverOver(){
        GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
    }
    public void HoverEnd(){
        GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
    }

}
