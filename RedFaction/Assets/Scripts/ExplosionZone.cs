using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionZone : MonoBehaviour
{
    public float timer;
    void Start()
    {
        StartCoroutine(soundExplode());
    }
    
    public IEnumerator soundExplode()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == "Ennemi")
        {
            hit.gameObject.GetComponent<EnnemieHealth>().ennemieHealth -= 50;
        }
    }
}
