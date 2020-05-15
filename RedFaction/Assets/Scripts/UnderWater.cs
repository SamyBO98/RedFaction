using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWater : MonoBehaviour
{
    public GameObject water;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;
    public bool isInWater;
    public Bullet b;
    public AudioClip waterSound;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerHead")
        {
            GetComponent<AudioSource>().PlayOneShot(waterSound);
            water.SetActive(true);
            isInWater = true;
            controller.m_JumpSpeed = 3;
            controller.m_RunSpeed = 4;
            controller.m_WalkSpeed = 3;
            controller.m_GravityMultiplier = 0.5f;
            
            
            
        }
        if (other.gameObject.tag == "PlayerHead" && b.test == true)
        {
            water.SetActive(true);
            isInWater = true;
            controller.m_JumpSpeed = 3;
            controller.m_RunSpeed = 4;
            controller.m_WalkSpeed = 3;
            controller.m_GravityMultiplier = 0.5f;



        }


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PlayerHead")
        {
            //water.SetActive(true);
            isInWater = true;
            controller.m_JumpSpeed = 3;
            controller.m_RunSpeed = 4;
            controller.m_WalkSpeed = 3;
            controller.m_GravityMultiplier = 0.5f;



        }
        if (other.gameObject.tag == "PlayerHead" && b.test == true)
        {
            water.SetActive(true);
            isInWater = true;
            controller.m_JumpSpeed = 3;
            controller.m_RunSpeed = 4;
            controller.m_WalkSpeed = 3;
            controller.m_GravityMultiplier = 0.5f;



        }
    }

    private void OnTriggerExit(Collider other)
    {
        water.SetActive(false);
        isInWater = false;
        controller.m_JumpSpeed = 8;
        controller.m_GravityMultiplier = 2;
        controller.m_WalkSpeed = 4;
        controller.m_RunSpeed = 8;
    }
}
