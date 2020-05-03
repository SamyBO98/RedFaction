using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BulletEnnemi : MonoBehaviour
{
    public EnnemieGunAI ega;
    public EnnemieGunHealth egh;
    public GameObject bullet;
    public Transform target;
    private float timerShots;
    public float timeBtwShots = 0.25f;
    public float fireRadius = 25f;
    public float force;

    private void Update()
    {
        if(ega.isAttacking == true && egh.isDead == false)
        {
            if (timerShots <= 0)
            {
                //Vector3 test = target.position;
                //Debug.Log(test);
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
                bulletClone.transform.Rotate(Vector3.left * 90);
                Rigidbody rb;
                rb = bulletClone.GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * force);
                timerShots = timeBtwShots;
            }
            else
            {
                timerShots -= Time.deltaTime;
            }
        }

    }



}
