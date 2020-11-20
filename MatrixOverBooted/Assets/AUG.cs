using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AUG : MonoBehaviour
{
    public Camera Playercamera;
    public float fireRate = 10f;
    public float timeBetweenNextShot;
    public float damage = 20f;
    public ParticleSystem muzzelFlash;
    public AudioSource n_gunShooting;

    void Update () {
        if (Input.GetButton("Fire1") && Time.time >= timeBetweenNextShot)
        {
           timeBetweenNextShot = Time.time + 1f/fireRate;
           weapon();
           muzzelFlash.Play();
           n_gunShooting.Play();
        }
        
    }
    void start () {
        n_gunShooting = GetComponent<AudioSource>();
    }
    void weapon () {
        
        RaycastHit hit;
        if (Physics.Raycast(Playercamera.transform.position , Playercamera.transform.forward ,out hit)) 
        {
            Health enemy = hit.transform.GetComponent<Health>();
            enemy.damage(damage);
        }
    }
    
}
