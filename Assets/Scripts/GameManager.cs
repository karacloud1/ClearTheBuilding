using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject levelFinishParent;
    private Target playerHealth;
    // Start is called before the first frame update
    void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Target>();
    }

    // Update is called once per frame
    void Update()
    {
        int enemyCount = FindObjectsOfType<Enemy>().Length;
        
        if (enemyCount <= 0 || playerHealth.GetHealth <= 0)
        {
            levelFinishParent.gameObject.SetActive(true);
        }
        else
        {
            levelFinishParent.gameObject.SetActive(false);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
