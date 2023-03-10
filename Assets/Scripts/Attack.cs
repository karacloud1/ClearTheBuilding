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
    [HideInInspector] public bool switchGun = false;
    [SerializeField] private int maxAmmoCount = 5;
    private int currentAmmoCount;
    [SerializeField] private bool isPlayer = false;
    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioSource source;
    public int GetAmmo
    {
        get
        {
            return currentAmmoCount;
        }
        set
        {
            currentAmmoCount = value;
            if (currentAmmoCount > maxAmmoCount)
            {
                currentAmmoCount = maxAmmoCount;
            }
        }
    }
    public int GetClipSize
    {
        get
        {
            return maxAmmoCount;
        }
    }
    public float GetCurrentFireRate { get { return currentFireRate; } set { currentFireRate = value; } }

    // Start is called before the first frame update
    void Awake()
    {
        currentAmmoCount = maxAmmoCount;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentFireRate > 0f)
        {
            currentFireRate -= Time.deltaTime;
        }
        PlayerInput();

    }

    private void PlayerInput()
    {
        if (isPlayer)
        {
            if (Input.GetMouseButtonDown(0) && currentFireRate <= 0 && currentAmmoCount > 0)
            {
                Fire(switchGun);
                switchGun = !switchGun;
            }

        }
    }

    public void Fire(bool switchGun)
    {
        currentAmmoCount--;
        currentFireRate = fireRate;
        source.PlayOneShot(clip);
        if (switchGun)
        {
            GameObject bulletClone = Instantiate(ammo, fireTransform1.position, fireTransform1.rotation);
            bulletClone.GetComponent<Bullet>().owner = gameObject;
            return;
        }
        GameObject bulletClone2 = Instantiate(ammo, fireTransform2.position, fireTransform2.rotation);
        bulletClone2.GetComponent<Bullet>().owner = gameObject;

    }
}
