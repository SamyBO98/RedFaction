using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
    public Ally a;
    public AudioClip audioSpeak;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            a.seePlayer = true;
            StartCoroutine(SoundTime());
        }
    }


    public IEnumerator SoundTime()
    {
        GetComponent<AudioSource>().PlayOneShot(audioSpeak);
        yield return new WaitForSeconds(audioSpeak.length);
        Destroy(gameObject);
    }
}
