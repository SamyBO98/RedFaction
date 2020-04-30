using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{

    void Update()
    {
        StartCoroutine(Test());
    }

    public IEnumerator Test()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
