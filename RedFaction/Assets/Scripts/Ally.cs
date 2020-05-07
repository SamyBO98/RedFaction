using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ally : MonoBehaviour
{


    public float distance;
    public Transform target;
    public int lookAtDistance;
    public int chaseRange;
    public int attackRange;
    public float moveSpeed;
    public int damping = 6;
    public CharacterController controller;
    public int gravity = 20;
    private Vector3 moveDirection;
    public bool isAttacking;
    private Rigidbody rb;
    public float x;
    public float y;
    public float z;
    public bool seePlayer;
    public Dialogue dial;
    public AllyHealth Ah;

    private void Start()
    {
       
       
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        distance = Vector3.Distance(target.position, transform.position);
        if (distance < lookAtDistance)
        {
            LookAt();
            isAttacking = false;
        }

        if (distance < attackRange)
        {
            WaitDialogue();
            transform.localRotation = Quaternion.Euler(x, y, z);
            isAttacking = true;
            

        }
        else if (distance < chaseRange && isAttacking == false && seePlayer == true)
        {
            Chase();
            
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
        GetComponent<Animator>().Play("Walk");

    }

    void WaitDialogue()
    {
        if(Ah.allyHealth != 0 && dial.canPunch == false)
        {
            GetComponent<Animator>().Play("Idle HandUp");
        }

        if(dial.canPunch == true && Ah.allyHealth !=0)
        {
            GetComponent<Animator>().Play("Hit");
        }
        
    }

    void LookAt()
    {
        Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
        //GetComponent<Animator>().Play("Idle HandUp");
    }
}
