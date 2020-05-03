using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BulletEnnemi : MonoBehaviour
{
    public EnnemieGunAI ega;
    public EnnemieGunHealth egh;
    public Rigidbody bullet;
    public Transform target;
    private float timerShots;
    public float timeBtwShots = 0.25f;
    public float fireRadius = 25f;
    public float force;

    private void Update()
    {
     // Transform = eject   

        if(ega.isAttacking == true && egh.isDead == false)
        {
            if (timerShots <= 0)
            {
                //Debug.Log(transform);
                //Debug.Log(target.position);
                //Vector3 test = target.position;
                //Debug.Log(test);
                Rigidbody bulletClone;
                bulletClone = Instantiate(bullet, transform.position +(target.position  - transform.position).normalized, Quaternion.LookRotation(target.position));
                bulletClone.velocity = (target.position - transform.position).normalized * 10;
                timerShots = timeBtwShots;
            }
            else
            {
                timerShots -= Time.deltaTime;
            }
        }
    }





}
