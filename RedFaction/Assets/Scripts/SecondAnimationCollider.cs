using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondAnimationCollider : MonoBehaviour
{
    public GameObject ally;
    public GameObject ennemy;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            ally.SetActive(true);
            ennemy.SetActive(true);
        }
    }
}
