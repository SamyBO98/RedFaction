using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmoBox : MonoBehaviour
{
    public Bullet b1;
    public Bullet b2;
    public int addReserveM4A1;
    public int addReservePistol;
    public AudioClip pickUpAmmo;
    public WeaponInventoryPistol wip;
    // Start is called before the first frame update
    private void Start()
    {
        wip = GameObject.Find("Gun").GetComponent<WeaponInventoryPistol>();

    }

    private void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == "Player")
        {
            b1.reserve += addReserveM4A1;
            if(wip.hasRiffle == true)
            {
                b2.reserve += addReservePistol;
            }
            
            GetComponent<AudioSource>().PlayOneShot(pickUpAmmo);
            StartCoroutine(DestroyAmmoBox());
        }
    }

    public IEnumerator DestroyAmmoBox()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

}
