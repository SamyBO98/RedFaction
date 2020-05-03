using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorBox : MonoBehaviour
{
    private PlayerStats ps;
    public AudioClip pickUp;
    void Start()
    {
        ps = GameObject.Find("PlayerStats").GetComponent<PlayerStats>();
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            ps.armorBase += 10;
            GetComponent<AudioSource>().PlayOneShot(pickUp);
            StartCoroutine(DestroyArmorBox());
        }
    }

    public IEnumerator DestroyArmorBox()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);

    }
}
