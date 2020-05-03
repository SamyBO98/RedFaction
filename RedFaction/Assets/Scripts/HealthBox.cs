using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBox : MonoBehaviour
{
    private PlayerStats ps;
    public AudioClip pickUp;
    void Start()
    {
       ps = GameObject.Find("PlayerStats").GetComponent<PlayerStats>();
    }

    private void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == "Player")
        {
            ps.healthBase += 10;
            GetComponent<AudioSource>().PlayOneShot(pickUp);
            StartCoroutine(DestroyHealthBox());
        }
    }

    public IEnumerator DestroyHealthBox()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
       
    }
}
