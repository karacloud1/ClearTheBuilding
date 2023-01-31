using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [Header("Health settings")]
    public bool healtPowerUp = false;
    public int healthAmount = 1;
    [Header("Ammo settings")]
    public bool ammoPowerUp = false;
    public int ammoAmount = 5;
    [Header("Transform settings")]
    [SerializeField] private float turnSpeed = -1f;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip;
    void Awake()
    {
        if (healtPowerUp && ammoPowerUp)
        {
            healtPowerUp = false;
            ammoPowerUp = false;
        }
        else if (healtPowerUp)
        {
            ammoPowerUp = false;
        }
        else if (ammoPowerUp)
        {
            healtPowerUp = false;
        }
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.Rotate(turnSpeed, 0f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            return;
        }
        AudioSource.PlayClipAtPoint(clip, transform.position);
        if (healtPowerUp)
        {
            other.gameObject.GetComponent<Target>().GetHealth += healthAmount;
            Destroy(gameObject);
        }
        else if (ammoPowerUp)
        {
            other.gameObject.GetComponent<Attack>().GetAmmo += ammoAmount;
            Destroy(transform.parent.gameObject);
        }

    }
}
