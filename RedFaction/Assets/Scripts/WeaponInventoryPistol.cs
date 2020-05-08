using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventoryPistol : MonoBehaviour
{
    public GameObject childObject;
    public Transform parentObject;
    public float x;
    public float y;
    public float z;
    public bool hasPistol;
    public bool hasRiffle;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            hasPistol = true;
            childObject.transform.SetParent(parentObject);
            childObject.transform.localRotation = Quaternion.Euler(x, y, z);
        }
    }
}
