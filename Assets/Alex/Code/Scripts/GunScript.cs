using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;


    private float nextTimeToFire = 0f;

    public Animator animator;

    void Start ()
    {
        currentAmmo = maxAmmo;
    }

    void OnEnable ()
    {
        //reloading animation
        isReloading = false;
        animator.SetBool("Reloading", false);
    }

    // Update is called once per frame
    void Update()
    {

        //when out of ammo, reload
        if (isReloading)
            return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        //when button is pressed, delay and go to shoot method
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        //play flash for gun
        muzzleFlash.Play();

        //after pressing shoot
        currentAmmo--;

        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            // enemy takes damage when hit
            Enemy enemy  = hit.transform.GetComponent<Enemy>();
            if ( enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            // enemy takes force with damage when hit
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            // shows impact effect in location that is hit with bullet
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 1f);
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");
        
        //animator switch
        animator.SetBool("Reloading", true);
  
        yield return new WaitForSeconds(reloadTime - .25f);
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(.25f);

        //ammo 
        currentAmmo = maxAmmo;
        isReloading = false;

    }
}
