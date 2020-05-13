using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SecondAnimation : MonoBehaviour
{


    public float distance;
    public Transform target;
    public Transform target2;
    public int lookAtDistance;
    public int chaseRange;
    public float moveSpeed;
    public int damping = 6;
    public CharacterController controller;
    public int gravity = 20;
    private Vector3 moveDirection;
    public bool isAttacking;
    public float x;
    public float y;
    public float z;
    public bool isAlly;
    public EnnemieHealth eh;
    public bool look;
    public GameObject col;

    private void Update()
    {

        distance = Vector3.Distance(target.position, transform.position);
        if (distance < lookAtDistance)
        {
            LookAt();
            isAttacking = false;
        }
        else if (distance < chaseRange && isAttacking == false && eh.ennemieHealth!=0)
        {
            Chase();
            //GetComponent<Animator>().Play("Idle");

        }

        if(eh.ennemieHealth ==0 && isAlly == true)
        {
            GetComponent<Animator>().Play("Idle HandUp");
            LookAtPlayer();
            look = true;
            col.SetActive(true);
            
            
        }



       

        

    }

    void Chase()
    {
        //transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(
    transform.position,
    new Vector3(
        target.transform.position.x,
        transform.position.y,
        target.transform.position.z
    ),
    moveSpeed * Time.deltaTime
);
        GetComponent<Animator>().Play("Run");

    }


    void LookAt()
    {
        Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
       
        //GetComponent<Animator>().Play("Idle HandUp");
    }

    void LookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(target2.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);

    }
}
