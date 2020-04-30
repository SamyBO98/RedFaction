using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{

    void Update()
    {
        StartCoroutine(DestroyB());
    }

    public IEnumerator DestroyB()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ennemi")
        {
            StartCoroutine(BulletDisappear());
        }
    }

    public IEnumerator BulletDisappear()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

}
