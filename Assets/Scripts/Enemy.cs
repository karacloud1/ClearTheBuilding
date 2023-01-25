using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] movePoints;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float turnSpeed = 15f;
    [SerializeField] private float reloadTime = 5f;
    [SerializeField] private float shootRange = 10f;
    [SerializeField] private LayerMask shootLayer;
    [SerializeField] private Transform aimTransform1;
    [SerializeField] private Transform aimTransform2;
    private Attack attack;
    private bool isReloaded = false;
    private bool canMoveRight = false;

    // Start is called before the first frame update
    void Awake()
    {
        attack = GetComponent<Attack>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckCanMoveRight();
        MoveTowards();
        Attack();

    }

    private void Reload()
    {
        attack.GetAmmo = attack.GetClipSize;
        isReloaded = false;
    }

    private void Attack()
    {
        if (attack.GetAmmo<=0 && isReloaded == false)
        {
            Invoke(nameof(Reload), reloadTime);
            isReloaded = true;
        }
        if (attack.GetCurrentFireRate <= 0f && attack.GetAmmo > 0 && Aim())
        {
            attack.Fire(attack.switchGun);
            attack.switchGun = !attack.switchGun;
        }
    }

    private void MoveTowards()
    {
        if (Aim() &&  attack.GetAmmo > 0)
        {
            return;
        }
        if (!canMoveRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(movePoints[0].position.x, transform.position.y, movePoints[0].position.z), speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 180f, 0f), turnSpeed * Time.deltaTime);
            //LookAtTheTarget(movePoints[0].position);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(movePoints[1].position.x, transform.position.y, movePoints[1].position.z), speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), turnSpeed * Time.deltaTime);
            //LookAtTheTarget(movePoints[1].position);
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

    private bool Aim()
    {
        bool hit = Physics.Raycast(aimTransform1.position, -transform.right, shootRange, shootLayer);
        //Debug.DrawRay(aimTransform1.position, -transform.right * shootRange, Color.red);
        //print("Can shoot :" + hit);
        return hit;
    }


    //private void LookAtTheTarget(Vector3 newTarget)
    //{
    //    print(newTarget);
    //    Vector3 newLook = new Vector3(newTarget.x, transform.position.y, newTarget.z);
    //    print(newLook);
    //    Quaternion targetRotation = Quaternion.LookRotation(newLook - transform.position);
    //    print(targetRotation);
    //    transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, speed * Time.deltaTime);
    //}


}
