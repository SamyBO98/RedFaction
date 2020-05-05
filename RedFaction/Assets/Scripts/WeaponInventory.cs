using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{
    public GameObject childObject;
    public Transform parentObject;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            childObject.transform.SetParent(parentObject);
        }
    }
}
