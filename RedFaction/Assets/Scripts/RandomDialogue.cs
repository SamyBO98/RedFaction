using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDialogue : MonoBehaviour
{
   
    public AudioClip audioSpeak;
    public Collider col;
    public AudioSource test;
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
        yield return new WaitForSeconds(audioSpeak.length);
        if(test != null)
        {
            test.Play();
        }
        //col.enabled = false;
        
    }
}
