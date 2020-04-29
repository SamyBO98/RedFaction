using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody bulletCasing;
    private Rigidbody bullet;
    public int ejectSpeed = 100;
    public float fireRate = 0.5f;
    private float fireCoolDown = 0f;
    private bool fullAuto = false;
    public int clip;
    public int maxClip;
    public int reserve;
    public AudioClip shotSound;
    public AudioClip reloadSound;
    public bool munitionMax;

    void Update()
    {
        
        //tirer sans coup par coup
        if(Input.GetButton("Fire1") && Time.time> fireCoolDown)
        {
            if (clip >= 1)
            {
                fireCoolDown = Time.time + fireRate;
                bullet = Instantiate(bulletCasing, transform.position, transform.rotation);
                clip -= 1;
                GetComponent<AudioSource>().PlayOneShot(shotSound);
                bullet.velocity = transform.TransformDirection(Vector3.left * ejectSpeed);
            }
        }

        if (Input.GetKeyDown("v"))
        {
            fullAuto = !fullAuto;
        }

        if(fullAuto == true)
        {
            fireRate = 0.1f;
        }
        else
        {
            fireRate = 0.5f;
        }

        if (Input.GetKeyDown("r") && munitionMax == false)
        {
            clip += 30;
            GetComponent<AudioSource>().PlayOneShot(reloadSound);
        }

        if(clip >= maxClip)
        {
            clip = 30;
        }

        if(clip >= 30)
        {
            munitionMax = true;
        }

        if(clip <= 29)
        {
            munitionMax = false;
        }
    }

    private void OnGUI()
    {
        GUI.contentColor = Color.green;
        GUI.Box(new Rect(600, 10, 50, 30), new GUIContent("" +clip));
        GUI.skin.box.fontSize = 20;

        if (fullAuto == true)
        {
            GUI.Box(new Rect(600, 50, 120, 30), new GUIContent("Full Auto ON"));
        }
        if(fullAuto == false)
        {
            GUI.Box(new Rect(600, 50, 130, 30), new GUIContent("Full Auto OFF"));
        }
    }

}
