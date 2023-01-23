using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] movePoints;
    [SerializeField] private float speed = 5f;
    private bool canMoveRight = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckCanMoveRight();
        MoveTowards();
    }

    private void MoveTowards()
    {
        if (!canMoveRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(movePoints[0].position.x, transform.position.y, movePoints[0].position.z), speed * Time.deltaTime);
            LookAtTheTarget(movePoints[0].position);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(movePoints[1].position.x, transform.position.y, movePoints[1].position.z), speed * Time.deltaTime);
            LookAtTheTarget(movePoints[1].position);
        }

    }

    private void CheckCanMoveRight()
    {
        if (Vector3.Distance(transform.position, movePoints[0].position) <= 0.1f)
        {
            canMoveRight = true;
        }
        else if (Vector3.Distance(transform.position, movePoints[1].position) <= 0.1f)
        {
            canMoveRight = false;
        }
    }

    private void LookAtTheTarget(Vector3 newTarget)
    {
        print(newTarget);
        Vector3 newLook = new Vector3(newTarget.x, transform.position.y, newTarget.z);
        print(newLook);
        Quaternion targetRotation = Quaternion.LookRotation(newLook - transform.position);
        print(targetRotation);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation , speed * Time.deltaTime);
    }
}
