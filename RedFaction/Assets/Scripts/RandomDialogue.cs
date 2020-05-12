using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomDialogue : MonoBehaviour
{
   
    public AudioClip audioSpeak;
    public Collider col;
    public AudioSource test;
    public Canvas eosDialogue1;
    public Canvas dialogue1;
    public Canvas dialogue2;
    public Canvas dialogue3;
    public Canvas dialogue4;
    public Canvas dialogue5;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            col.enabled = false;
            StartCoroutine(SoundTime());
        }
    }


    public IEnumerator SoundTime()
    {
        GetComponent<AudioSource>().PlayOneShot(audioSpeak);
        yield return new WaitForSeconds(21);
        if(eosDialogue1 != null)
        {
            eosDialogue1.enabled = true;
            

        }
        if(dialogue1 != null)
        {
            dialogue1.enabled = true;
            yield return new WaitForSeconds(6.7f);
            dialogue1.enabled = false;
        }

        if(dialogue2 != null)
        {
            dialogue2.enabled = true;
            yield return new WaitForSeconds(3.5f);
            dialogue2.enabled = false;
        }

        if(dialogue3 != null)
        {
            dialogue3.enabled = true;
            yield return new WaitForSeconds(4f);
            dialogue3.enabled = false;
        }

        if(dialogue4 != null)
        {
            dialogue4.enabled = true;
            yield return new WaitForSeconds(6.2f);
            dialogue4.enabled = false;
        }
        
        if(dialogue5 != null)
        {
            dialogue5.enabled = true;
            yield return new WaitForSeconds(2);
            dialogue5.enabled = false;
            eosDialogue1.enabled = false;
        }
        
        
        
        if(test != null)
        {
            test.Play();
        }
        //col.enabled = false;
        
    }
}
