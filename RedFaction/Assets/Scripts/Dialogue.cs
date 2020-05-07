using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public AudioSource audio1;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ally")
        {
            audio1.Play();
        }
    }
}
