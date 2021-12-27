using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if(Input.GetButtonDown ("Fire1")){
            Instantiate (Resources.Load ("Projectile"), transform.position, transform.rotation);
        }
    }
}
