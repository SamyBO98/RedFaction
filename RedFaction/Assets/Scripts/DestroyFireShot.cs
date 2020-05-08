using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFireShot : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(DestroyFireAnim());
    }
    public IEnumerator DestroyFireAnim()
    {
        yield return new WaitForSeconds(0.02f);
        Destroy(gameObject);
    }
}
