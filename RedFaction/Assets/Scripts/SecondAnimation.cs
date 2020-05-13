using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SecondAnimation : MonoBehaviour
{


    public float distance;
    public float distance2;
    public Transform target;
    public Transform target2;
    public Transform target3;
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
    public Dialogue2 d2;
    public bool speak;
    public GameObject explosion;

    private void Update()
    {
        if(target != null)
        {
            distance = Vector3.Distance(target.position, transform.position);
        }
        
        distance2 = Vector3.Distance(target3.position, transform.position);
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

        if(eh.ennemieHealth ==0 && isAlly == true && speak == true)
        {
            GetComponent<Animator>().Play("Idle HandUp");
            LookAtPlayer();
            look = true;
            col.SetActive(true);
            
            
        }

        StartCoroutine(ChaseOther());
        


       

        

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

    void LookOther()
    {
        Quaternion rotation = Quaternion.LookRotation(target3.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    }

    void ChaseFast()
    {
        transform.position = Vector3.MoveTowards(transform.position, target3.position, moveSpeed * Time.deltaTime);
    }
    public IEnumerator ChaseOther()
    {
        if(d2.speak == true && isAlly == true)
        {
            yield return new WaitForSeconds(13);
            speak = false;
            ChaseFast();
            LookOther();
            GetComponent<Animator>().Play("Run");
            yield return new WaitForSeconds(3);
            


        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Explode")
        {
            Instantiate(explosion, target3.transform.position, target3.transform.rotation);
            Destroy(gameObject);
            
        }
    }
}
