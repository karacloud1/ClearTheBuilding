using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject ammo;
    [SerializeField] private Transform fireTransform1;
    [SerializeField] private Transform fireTransform2;
    [SerializeField] private float fireRate = 0.5f;
    private float currentFireRate = 0f;
    private bool switchGun = false;
    private int ammoCount = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentFireRate > 0f)
        {
            currentFireRate -= Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0) && currentFireRate <= 0 && ammoCount > 0)
        {
            Fire(switchGun);
            switchGun = !switchGun;
        }
    }

    private void Fire(bool switchGun)
    {
        ammoCount--;
        currentFireRate = fireRate;
        if (switchGun)
        {
            Instantiate(ammo, fireTransform1.position, fireTransform1.rotation);
            return;
        }
        Instantiate(ammo, fireTransform2.position, fireTransform2.rotation);


    }
}
