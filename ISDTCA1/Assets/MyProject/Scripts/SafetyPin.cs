using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyPin : MonoBehaviour
{
    
    void OnCollisionExit(Collision col){
        if (col.gameObject.name == "SafetyPin"){
            Debug.Log("Pulled!");
            this.GetComponent<ShootWater>().enabled = false;
        }
    }
}
