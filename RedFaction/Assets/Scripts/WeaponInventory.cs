using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{
    public GameObject childObject;
    public Transform parentObject;
    public float x;
    public float y;
    public float z;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            childObject.transform.SetParent(parentObject);
            childObject.transform.localRotation = Quaternion.Euler(x, y, z);
        }
    }
}
