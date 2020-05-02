using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiAI : MonoBehaviour
{
    public float distance;
    public Transform target;
    public int lookAtDistance;
    public int chaseRange;
    public float attackRange;
    public int moveSpeed;
    public int dumping;
    public int attackRepeatTime;
    public int dmg;
    private float attackTime;
    public CharacterController characterController;
    public float gravity;
    public Vector3 moveDirection;
    

    void Start()
    {
        attackTime = Time.time;
        //FindHealth();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(target.position, transform.position);

        if(distance < lookAtDistance)
        {
            LookAt();
        }
        if(distance < attackRange)
        {
            //attack();
        }
        else if(distance < chaseRange)
        {
            //chase();
        }
    }

    void LookAt()
    {
        Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * dumping);
    }
}
