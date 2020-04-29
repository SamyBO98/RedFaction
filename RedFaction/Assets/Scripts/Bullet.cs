using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody bulletCasing;
    private Rigidbody bullet;
    public int ejectSpeed = 100;
    public float fireRate = 0.5f;
    private float fireCoolDown = 0f;
    private bool fullAuto = false;

    void Update()
    {
        
        //tirer sans coup par coup
        if(Input.GetButton("Fire1") && Time.time> fireCoolDown)
        {
            fireCoolDown = Time.time + fireRate;
            bullet = Instantiate(bulletCasing, transform.position, transform.rotation);
            bullet.velocity = transform.TransformDirection(Vector3.left * ejectSpeed);
        }

        if (Input.GetKeyDown("v"))
        {
            fullAuto = !fullAuto;
        }

        if(fullAuto == true)
        {
            fireRate = 0.1f;
        }
        else
        {
            fireRate = 0.5f;
        }
    }

}
