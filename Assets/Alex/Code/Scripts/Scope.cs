using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    public Animator animator;

    public GameObject scopeOverlay;
    public GameObject gunCrosshair;
    public GameObject weaponCamera;
    public Camera mainCamera;

    public float scopedFOV = 15f;
    private float normalFOV = 85f;

    private bool isScoped = false;

    void Update()
    {
        // when pressing scope button, change scope animation status
        if (Input.GetButtonDown("Fire2"))
        {
            isScoped = !isScoped;
            animator.SetBool("Scoped", isScoped);
        }

        if (isScoped)
            StartCoroutine(OnScoped());
        else
            OnUnscoped();
    }

    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(.15f);

        gunCrosshair.SetActive(false);
        scopeOverlay.SetActive(true);
        weaponCamera.SetActive(false);

       
        mainCamera.fieldOfView = scopedFOV;
    }

    void OnUnscoped()
    {
        gunCrosshair.SetActive(true);
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);

        mainCamera.fieldOfView = normalFOV;
    }

}
