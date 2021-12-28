using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    public GameObject myWeapon;
    public GameObject weaponOnGround;
    void Start(){
        myWeapon.SetActive(false);
    }
    void OnTriggerEnter(Collider _collider){
        if(_collider.gameObject.tag=="Player"){
            myWeapon.SetActive(true);
            weaponOnGround.SetActive(false);
        }
    }
    
}
