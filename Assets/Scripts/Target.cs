using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int maxhealth = 2;
    private int currentHealth = 2;
    [SerializeField] private GameObject deadFx;
    [SerializeField] private GameObject hitFx;
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

    }
    private void OnTriggerEnter(Collider other)
    {
        Bullet bullet = other.GetComponent<Bullet>();
        if (bullet != null && bullet.owner != gameObject && currentHealth > 0)
        {
            currentHealth--;
            if (hitFx != null)
            {
                Instantiate(hitFx, transform.position, Quaternion.identity);
            }
            Destroy(other.gameObject);
            if (currentHealth <= 0)
            {
                if (deadFx != null)
                {
                    Instantiate(deadFx, transform.position, Quaternion.identity);
                }
                Destroy(gameObject);
            }
        }
    }


}
