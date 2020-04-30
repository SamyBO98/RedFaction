using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour
{
    private PlayerStats ps;
    public Rigidbody grenadeCasing;
    private Rigidbody grenade;
    public int ejectSpeed;
    void Start()
    {
        ps = GameObject.Find("FPSController").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ps.grenadeNumber >= 1)
        {
            if (Input.GetKeyDown("g"))
            {
                grenade = Instantiate(grenadeCasing, transform.position, transform.rotation);
                grenade.velocity = transform.TransformDirection(Vector3.forward * ejectSpeed);
                ps.grenadeNumber -= 1;
            }
        }
    }

}
