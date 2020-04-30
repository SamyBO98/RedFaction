using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemieHealth : MonoBehaviour
{

    public int ennemieHealth;
    public int damage;

    void Update()
    {
        //Debug.Log(ennemieHealth);
        if(ennemieHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            ennemieHealth -= damage;
        }
    }
}
