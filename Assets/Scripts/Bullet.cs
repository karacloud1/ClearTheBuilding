using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    public GameObject owner;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.right * speed * Time.deltaTime;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Target>() == false)
        {
            Destroy(gameObject);
        }
    }


}
