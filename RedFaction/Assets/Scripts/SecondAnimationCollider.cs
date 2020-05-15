using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SecondAnimationCollider : MonoBehaviour
{
    public GameObject ally;
    public GameObject ennemy;
    public AudioClip help;
    public Collider col;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            col.enabled = false;
            ally.SetActive(true);
            ennemy.SetActive(true);
            GetComponent<AudioSource>().PlayOneShot(help);
        }
    }
}
