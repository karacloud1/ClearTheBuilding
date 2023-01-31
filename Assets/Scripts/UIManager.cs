using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image healthFill;
    private Target playerHealth;
    // Start is called before the first frame update
    void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Target>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthFill();
    }

    private void UpdateHealthFill()
    {
        healthFill.fillAmount = (float)playerHealth.GetHealth / playerHealth.GetMaxHealth;
    }
}
