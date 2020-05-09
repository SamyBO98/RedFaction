using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public GameObject doorLeft;
    public GameObject doorRight;
    public Transform target;
    public Transform target2;
    Vector3 original;
    Vector3 original2;
    public bool open;
    public int speed;

    private void Start()
    {
        original = doorLeft.transform.position;
        original2 = doorRight.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            open = true;
            //Debug.Log("ouverture");
            Open();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            open = true;
            //Debug.Log("ouverture");
            Open();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        doorLeft.transform.position = original;
        doorRight.transform.position = original2;
    }

    void Open()
    {
        doorLeft.transform.position = Vector3.MoveTowards(doorLeft.transform.position, target.position, speed * Time.deltaTime);
        doorRight.transform.position = Vector3.MoveTowards(doorRight.transform.position, target2.position, speed * Time.deltaTime);
    }
}
