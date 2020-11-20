using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK : MonoBehaviour
{
    public Camera Playercamera;
    public float fireRate = 10f;
    public float timeBetweenNextShot;
    public float damage = 20f;
    public ParticleSystem muzzelFlash;
    public AudioSource m_gunShooting;
    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;
    public Animator animator;
    public AudioSource a_gunShooting;
    void start () 
    {
        currentAmmo = maxAmmo;
    }
    void OnEnable ()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }
    void Update () {
        if (isReloading)
            return;
        
        
        if (Input.GetButton("Fire1") && Time.time >= timeBetweenNextShot)
        {
           if (currentAmmo <= 0)
           {
               StartCoroutine(Reload());
               return;
           }
           timeBetweenNextShot = Time.time + 1f/fireRate;
           weapon();
           muzzelFlash.Play();
           m_gunShooting.Play();
           
        }
        
    }

    IEnumerator Reload ()
    {
        isReloading = true;
        
        Debug.Log("Reloading.....");
        animator.SetBool("Reloading", true);
        a_gunShooting.Play();
        yield return new WaitForSeconds(reloadTime + 1f);
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(1.5f);
        currentAmmo = maxAmmo;
        isReloading = false;
    }
    void Start () {
        m_gunShooting = GetComponent<AudioSource>();
    }
    void play () {
        a_gunShooting = GetComponent<AudioSource>();
    }
    void weapon () {
        
        RaycastHit hit;
        if (Physics.Raycast(Playercamera.transform.position , Playercamera.transform.forward ,out hit)) 
        {
            Health enemy = hit.transform.GetComponent<Health>();
            enemy.damage(damage);
            currentAmmo--;
        }
    }
    
}
