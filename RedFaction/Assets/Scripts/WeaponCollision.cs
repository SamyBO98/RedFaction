using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollision : MonoBehaviour
{
   
    public AudioClip takeWeapon;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(PickUpWeapon());
        }
    }

    public IEnumerator PickUpWeapon()
    {
        GetComponent<AudioSource>().PlayOneShot(takeWeapon);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
