using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int maxhealth = 2;
     private int currentHealth = 2;
    public int GetHealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = value;
            if (currentHealth>maxhealth)
            {
                currentHealth = maxhealth;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            currentHealth--;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Bullet bullet = other.GetComponent<Bullet>();
        if (bullet != null && bullet.owner != gameObject)
        {
            currentHealth--;
            Destroy(other.gameObject);
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }


}
