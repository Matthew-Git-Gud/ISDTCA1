using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward*Time.deltaTime*10);
    }
    void OnTriggerEnter(Collider other){
        if (other.tag == "Enemy"){
            Debug.Log("Hit!");
            Destroy (other.gameObject);
            
        }
    }
}
