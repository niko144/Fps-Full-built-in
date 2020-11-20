using System.Collections;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public int selectedWeapon = 0;
    public Animator animator;
    private bool isScooped = false;
    public GameObject scopeOverlay;
    
    
    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon(); 
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;
        if (Input.GetButtonDown("Fire2"))
        {
            isScooped = !isScooped;
            animator.SetBool("Scoped", isScooped);
            scopeOverlay.SetActive(isScooped);
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectedWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedWeapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            selectedWeapon = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && transform.childCount >= 5)
        {
            selectedWeapon = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6) && transform.childCount >= 6)
        {
            selectedWeapon = 5;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7) && transform.childCount >= 7)
        {
            selectedWeapon = 6;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8) && transform.childCount >= 8)
        {
            selectedWeapon = 7;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9) && transform.childCount >= 9)
        {
            selectedWeapon = 8;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0) && transform.childCount >= 10)
        {
            selectedWeapon = 9;
        }
        if (Input.GetKeyDown("p") && transform.childCount >= 11)
        {
            selectedWeapon = 10;
        }
        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    void SelectWeapon () {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
        if (isScooped)
            StartCoroutine(OnScoped());
        else
            OnUnScoped();
    }
    IEnumerator OnScoped ()
    {
        
        
        yield return new WaitForSeconds(.15f);

        scopeOverlay.SetActive(true);
        
    }
    void OnUnScoped ()
    {
        scopeOverlay.SetActive(false);
        
    }
}
