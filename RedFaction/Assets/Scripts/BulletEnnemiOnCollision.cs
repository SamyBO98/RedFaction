using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnnemiOnCollision : MonoBehaviour
{
    public GameObject canvas;

    private void Start()
    {
        canvas.SetActive(false);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(CanvasShow());
            Destroy(gameObject);
        }
    }

    public IEnumerator CanvasShow()
    {
        canvas.SetActive(true);
        yield return new WaitForSeconds(1);
        canvas.SetActive(false);
    }


}
