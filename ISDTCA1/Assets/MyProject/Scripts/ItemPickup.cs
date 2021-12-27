using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if(other.tag == "Weapon"){
            Destroy (other.gameObject);
        }
    }
    
}
