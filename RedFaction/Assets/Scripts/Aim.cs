using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{

    public Vector3 normalPos;
    public Vector3 aimPos;
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = normalPos;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire2"))
        {
            transform.localPosition = aimPos;
        }
        else
        {
            transform.localPosition = normalPos;
        }
        
    }
}
