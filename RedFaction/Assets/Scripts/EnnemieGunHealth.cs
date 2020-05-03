using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemieGunHealth : MonoBehaviour
{

    public int ennemieHealth;
    public int damage;
    public GameObject ammoBox;
    public GameObject healthBox;
    public GameObject armorBox;
    public int randAmmoAppear;
    public int randHealthAppear;
    public int randArmorAppear;

    private void Start()
    {
        ammoBox.SetActive(false);
        Random.InitState((int)System.DateTime.Now.Ticks);
        randAmmoAppear = Random.Range(0, 2);

        healthBox.SetActive(false);
        randHealthAppear = Random.Range(0, 2);

        armorBox.SetActive(false);
        randAmmoAppear = Random.Range(0, 2);

    }
    void Update()
    {
        //Debug.Log(ennemieHealth);
        if (ennemieHealth <= 0)
        {
            //Debug.Log(randHealthAppear);
            //Debug.Log(randAmmoAppear);
            GetComponent<Animator>().Play("Die");
            //gameObject.GetComponent<EnnemiAI>().enabled = false;
            gameObject.GetComponent<EnnemieGunAI>().enabled = false;
            gameObject.GetComponent<CharacterController>().enabled = false;
            StartCoroutine(Dead());
            if (randAmmoAppear == 1)
            {
                ammoBox.SetActive(true);
            }
            else
            {
                ammoBox.SetActive(false);
            }

            if (randHealthAppear == 0)
            {
                healthBox.SetActive(true);
            }
            else
            {
                healthBox.SetActive(false);
            }

            if (randArmorAppear == 0)
            {
                armorBox.SetActive(true);
            }
            else
            {
                armorBox.SetActive(false);
            }

        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            ennemieHealth -= damage;
        }
    }


    public IEnumerator Dead()
    {
        yield return new WaitForSeconds(30);
        Destroy(gameObject);
    }



}
