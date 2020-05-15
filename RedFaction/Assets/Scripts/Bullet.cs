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
    public int minReserve;
    public AudioClip shotSound;
    public AudioClip reloadSound;
    public AudioClip silenceSound;
    public bool munitionMax;
    public bool silence;
    public GameObject silenceWeapon;
    private PlayerStats ps;
    public bool automatic;
    public float buttonPressed;
    public GameObject fireShot;
    public bool test;
    public UnderWater uw;

    private void Start()
    {
        silenceWeapon.SetActive(false);
        ps = GameObject.Find("PlayerStats").GetComponent<PlayerStats>();
    }
    void Update()
    {
        
        if(uw.isInWater == false)
        {
            if (Input.GetButton("Fire1") && Time.time > fireCoolDown)
            {
                test = true;
                //Debug.Log(maxClip - clip);
                if (clip >= 1)
                {
                    Instantiate(fireShot, silenceWeapon.transform.position, silenceWeapon.transform.rotation);
                    fireCoolDown = Time.time + fireRate;
                    bullet = Instantiate(bulletCasing, transform.position, transform.rotation);
                    clip -= 1;
                    if (silence == false)
                    {
                        GetComponent<AudioSource>().PlayOneShot(shotSound);
                    }
                    else
                    {
                        GetComponent<AudioSource>().PlayOneShot(silenceSound);
                    }
                    bullet.velocity = transform.TransformDirection(Vector3.left * ejectSpeed);
                }
            }
        }
       


        if (Input.GetKeyDown("v") && automatic == true)
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

        if (Input.GetKeyDown("r") && reserve != 0 && maxClip - clip <= reserve && clip != maxClip)
        {
            GetComponent<AudioSource>().PlayOneShot(reloadSound);

            RemoveReserve();
            clip += maxClip - clip;
        }

        if (Input.GetKeyDown("r") && reserve != 0 && maxClip - clip > reserve && clip!=maxClip)
        {
            GetComponent<AudioSource>().PlayOneShot(reloadSound);
            clip += reserve;
            reserve = 0;
        }



        if (reserve <= 0)
        {
            reserve = 0;
        }

        if(clip >= maxClip)
        {
            clip = maxClip;
        }

        if (Input.GetKeyDown("t"))
        {
            silence = !silence;
        }


        if(silence == true)
        {
            silenceWeapon.SetActive(true);
        }
        else
        {
            silenceWeapon.SetActive(false);
        }


    }

    private void OnGUI()
    {
        GUI.contentColor = Color.green;
        GUI.Box(new Rect(1700, 10, 50, 30), new GUIContent("" +clip));
        GUI.skin.box.fontSize = 20;

        if (fullAuto == true)
        {
            GUI.Box(new Rect(1700, 50, 120, 30), new GUIContent("Full Auto ON"));
        }
        if(fullAuto == false)
        {
            GUI.Box(new Rect(1700, 50, 130, 30), new GUIContent("Full Auto OFF"));
        }

        GUI.Box(new Rect(1755, 10, 50, 30), new GUIContent("" + reserve));
        if (silence == true)
        {
            GUI.Box(new Rect(1700, 90, 152, 30), new GUIContent("Mode Silencieux"));
        }
        if(silence == false)
        {
            GUI.Box(new Rect(1700, 90, 152, 30), new GUIContent("Mode Normal"));
        }

        GUI.Box(new Rect(10, 90, 152, 30), new GUIContent("Grenade(s) : " + ps.grenadeNumber));
    }



    private void RemoveReserve()
    {
        reserve -= maxClip - clip;
    }


}
