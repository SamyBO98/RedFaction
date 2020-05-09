using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnnemiOnCollision : MonoBehaviour
{
    public GameObject canvas;
    public PlayerStats ps;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(canvas, transform.position, transform.rotation);
            if(ps.armorBase <= 0)
            {
                ps.healthBase -= 15;
            }
            else
            {
                ps.armorBase -= 10;
            }
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Decor")
        {
            Destroy(gameObject);
        }
    }




}
