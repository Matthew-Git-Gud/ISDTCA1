using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullets : MonoBehaviour
{
    public GameObject bullet;

	[SerializeField] private GameObject muzzlePt;
    [SerializeField] private float bulletSpeed = 100f;
    [SerializeField] private AudioSource audioSource;

    public void OnShoot()
{
    GameObject tmpBullet;
    tmpBullet = Instantiate(bullet, muzzlePt.transform.position,  Quaternion.identity);
    tmpBullet.GetComponent<Rigidbody>().AddForce(muzzlePt.transform.forward *  bulletSpeed);

    audioSource.Play(); //play handgun sound
}


}
