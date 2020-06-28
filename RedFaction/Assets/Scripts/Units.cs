using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Units : MonoBehaviour
{
    public Transform target;
    float speed = 10f;
    public float distance;
    public float rangeAttack;
    Vector3[] path;
    int targetIndex;
    public int test;


    private void Start()
    {
        //PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
    }

    private void Update()
    {
        //rangeAttack = Vector3.Distance(transform.position, target.position);
        distance = Vector3.Distance(target.position, transform.position);
        if(distance < 20)
        {
            PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
            speed = 2f;
        }
        else
        {
            PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
            speed = 0;
        }

        // PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
       
        //PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
    } 

    public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
    {
        if (pathSuccessful)
        {
            path = newPath;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }

    IEnumerator FollowPath()
    {
        
        if (path.Length == 0 || path.Length == 1)
        {
           // Debug.Log("Oui");
            yield break;
        }
            
        Vector3 currentWaypoint = path[0];
        targetIndex = 0;

        while (true)
        {
            if(transform.position == currentWaypoint)
            {
                //Debug.Log("test");
                targetIndex++;
                if (targetIndex >= path.Length)
                {
                    targetIndex = 0;
                    path = new Vector3[0];
                    yield break;
                }
                currentWaypoint = path[targetIndex];
            }
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
            yield return null;
        }
    }

    public void OnDrawGizmos()
    {
        if(path != null)
        {
            for(int i = targetIndex; i<path.Length; i++)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawCube(path[i], Vector3.one);
                if(i == targetIndex)
                {
                    Gizmos.DrawLine(transform.position, path[i]);
                }
                else
                {
                    Gizmos.DrawLine(path[i - 1], path[i]);
                }
               
            }
        }
    }
}
