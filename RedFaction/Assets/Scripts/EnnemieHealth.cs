using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemieHealth : MonoBehaviour
{

    public int ennemieHealth;
    public int damage;
    public GameObject ammoBox;
    public int randAmmoAppear;

    private void Start()
    {
        ammoBox.SetActive(false);
    }
    void Update()
    {
        //Debug.Log(ennemieHealth);
        if(ennemieHealth <= 0)
        {
            Random.InitState((int)System.DateTime.Now.Ticks);
            randAmmoAppear = Random.Range(0, 2);
            Debug.Log(randAmmoAppear);
            Destroy(gameObject);
            if(randAmmoAppear == 1)
            {
                ammoBox.SetActive(true);
            }
            else
            {
                ammoBox.SetActive(false);
            }
            
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            ennemieHealth -= damage;
        }
    }



}
