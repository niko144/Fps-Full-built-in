using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMG9 : MonoBehaviour
{
    public Camera Playercamera;
    public float fireRate = 10f;
    public float timeBetweenNextShot;
    public float damage = 20f;
    public ParticleSystem muzzelFlash;
    public AudioSource t_gunShooting;

    void Update () {
        if (Input.GetButton("Fire1") && Time.time >= timeBetweenNextShot)
        {
           timeBetweenNextShot = Time.time + 1f/fireRate;
           weapon();
           muzzelFlash.Play();
           t_gunShooting.Play();
        }
        
    }
    void start () {
        t_gunShooting = GetComponent<AudioSource>();
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
