using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyHealth : MonoBehaviour
{
    public GameObject ennemie;
    public int allyHealth;
    public GameObject gun;

    private void Start()
    {
        gun.SetActive(false);
    }
    void Update()
    {
        //Debug.Log(ennemieHealth);
        if (allyHealth <= 0)
        {
            ennemie.GetComponent<Animator>().Play("Death");
            StartCoroutine(AllyDie());
            gameObject.GetComponent<CharacterController>().enabled = false;
            StartCoroutine(Dead());
        }
    }


    public IEnumerator Dead()
    {
        yield return new WaitForSeconds(30);
        Destroy(gameObject);
    }

    public IEnumerator AllyDie()
    {
        yield return new WaitForSeconds(1.5f);
        GetComponent<Animator>().Play("Death");
        if (gun != null)
        {
            gun.SetActive(true);
        }
    }






}
