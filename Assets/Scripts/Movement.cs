using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody playerRb;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpPower = 13f;
    [SerializeField] private float turnSpeed = 15f;
    [SerializeField] private Transform[] rayStartPoints;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        TakeInput();
        print(OnGroundCheck());
    }

    private void TakeInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            playerRb.velocity = new Vector3(Mathf.Clamp(speed * 100 * Time.deltaTime,0f,15f), playerRb.velocity.y, 0f);
            //transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 179.99f, 0f), turnSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerRb.velocity = new Vector3(Mathf.Clamp(-speed * 100 * Time.deltaTime, -15f, 0f), playerRb.velocity.y, 0f);
            //transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), turnSpeed * Time.deltaTime);

        }
        else
        {
            playerRb.velocity = new Vector3(0f,playerRb.velocity.y,0f);
        }
        if (Input.GetKeyDown(KeyCode.Space) && OnGroundCheck())
        {
            playerRb.velocity = new Vector3(playerRb.velocity.x, Mathf.Clamp(jumpPower * 100 * Time.deltaTime, 0f, 15f), 0f);
        }
    }

    private bool OnGroundCheck()
    {
        for (int i = 0; i < rayStartPoints.Length; i++)
        {
            if (Physics.Raycast(rayStartPoints[i].position, -rayStartPoints[i].transform.up, 0.5f)) return true;
            Debug.DrawRay(rayStartPoints[i].position, -rayStartPoints[i].transform.up * 0.25f,Color.red);
        }
        return false;
    }
}
