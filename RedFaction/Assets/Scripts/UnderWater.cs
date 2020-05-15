using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWater : MonoBehaviour
{
    public GameObject water;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;
    public bool isInWater;
    public bool canSwim;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerHead")
        {
            water.SetActive(true);
            isInWater = true;
            
            
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        water.SetActive(false);
        isInWater = false;
    }
}
