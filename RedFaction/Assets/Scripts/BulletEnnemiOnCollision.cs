using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnnemiOnCollision : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("touché");
            Destroy(gameObject);
        }
    }
}
