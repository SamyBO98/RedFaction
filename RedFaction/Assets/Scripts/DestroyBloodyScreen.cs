using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBloodyScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyBloodScreen());
    }

    public IEnumerator DestroyBloodScreen()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
