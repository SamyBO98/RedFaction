using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue2 : MonoBehaviour
{
    public AudioSource audioDial;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ally")
        {
            audioDial.Play();
        }
    }
}
