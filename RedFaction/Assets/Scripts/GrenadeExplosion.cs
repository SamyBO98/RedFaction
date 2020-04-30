using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour
{
    public int timer = 3;
    public GameObject explosionZone;
    void Start()
    {
        StartCoroutine(explosion());
    }
    void Update()
    {
        
    }

    public IEnumerator explosion()
    {
        yield return new WaitForSeconds(timer);
        Appear();
    }

    void Appear()
    {
        Instantiate(explosionZone, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
