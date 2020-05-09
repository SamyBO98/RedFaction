using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemieDamages : MonoBehaviour
{
    public ParticleSystem blood;
    public EnnemieGunHealth egh;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            blood.Play();
            egh.ennemieHealth -= 10;
        }
    }
}
