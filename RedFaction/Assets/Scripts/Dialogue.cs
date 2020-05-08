using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public AudioSource audio1;
    public AllyHealth Ah;
    public GameObject ally;
    public bool canPunch;
    public AudioSource audio2;
    public AudioSource audio3;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ally")
        {
            audio1.Play();
            StartCoroutine(DieAll());
        }
    }

    
   
    public IEnumerator DieAll()
    {
        yield return new WaitForSeconds(14.5f);
        canPunch = true;
        yield return new WaitForSeconds(0.5f);
        Ah.allyHealth = 0;
        audio2.Play();
        yield return new WaitForSeconds(5);
        audio3.Play();
        

    }
}
