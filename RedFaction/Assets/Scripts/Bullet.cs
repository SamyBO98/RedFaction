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
    public AudioClip shotSound;
    public AudioClip reloadSound;

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
    }

    private void OnGUI()
    {
        GUI.contentColor = Color.green;
        GUI.Box(new Rect(600, 10, 50, 30), new GUIContent("" +clip));
        GUI.skin.box.fontSize = 20;
    }

}
