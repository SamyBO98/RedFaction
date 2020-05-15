using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWater : MonoBehaviour
{
    public GameObject water;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Throw")
        {
            water.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        water.SetActive(false);
    }
}
