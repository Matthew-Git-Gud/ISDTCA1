using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWater : MonoBehaviour
{
    public bool Pulled = false;

    public void onSafetyPinPull()
    {
        Debug.Log("Pulled!");
        Pulled = true;
    }

    public void OnShoot()
    {
        if (Pulled == true)
        {
            Instantiate(Resources.Load("Projectile"), transform.position, transform.rotation);
        }
    }
    public void HoverOver(){
        GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
    }
    public void HoverEnd(){
        GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
    }

}
