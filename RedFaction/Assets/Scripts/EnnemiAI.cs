using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemiAI : MonoBehaviour
{
    

    public float distance;
    public Transform target;
    public int lookAtDistance;
    public int chaseRange;
    public int attackRange;
    public float moveSpeed;
    public int damping = 6;
    public int dmg = 10;
    private float attackTime;
    public float attackRepeatTime = 1;
    public CharacterController controller;
    public int gravity = 20;
    private Vector3 moveDirection;
    public bool isAttacking;
    public AudioClip punch;
    private Rigidbody rb;

    private void Start()
    {
        attackTime = Time.time;
        FindHealth();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
        distance = Vector3.Distance(target.position, transform.position);

        if(distance < lookAtDistance)
        {
            LookAt();
            isAttacking = false;
        }

        if(distance < attackRange)
        {
            Attack();
            isAttacking = true;
           
        }
        else if(distance < chaseRange && isAttacking == false)
        {
            Chase();
        }

        if(distance > chaseRange)
        {
            GetComponent<Animator>().Play("Idle HandUp");
        }
    }

    void LookAt()
    {
        Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
        //GetComponent<Animator>().Play("Idle HandUp");
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

    void Attack()
    {
        if(Time.time > attackTime)
        {
            GetComponent<Animator>().Play("Hit");
            GetComponent<AudioSource>().PlayOneShot(punch);
            target.SendMessage("ApplyDamage", dmg);
            attackTime = Time.time + attackRepeatTime;
            //StartCoroutine(tempoAttack());
        }
    }

    void ApplyDamage()
    {
        chaseRange += 20;
        moveSpeed += 2;
        lookAtDistance += 40;
    }

    void FindHealth()
    {
        target = GameObject.Find("PlayerStats").GetComponent<PlayerStats>().transform;
    }

}
