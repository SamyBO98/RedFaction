using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockEnnemieRotation : MonoBehaviour
{
    
    void Update()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
