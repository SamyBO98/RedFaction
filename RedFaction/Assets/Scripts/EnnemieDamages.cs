using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemieDamages : MonoBehaviour
{
    public EnnemieGunHealth egh;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Debug.Log("touché");
            egh.ennemieHealth -= 10;
        }
    }
}
