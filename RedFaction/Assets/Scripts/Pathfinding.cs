using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;

public class Pathfinding : MonoBehaviour
{

    GridAStar grid;
    PathRequestManager requestManager;

    private void Awake()
    {
        grid = GetComponent<GridAStar>();
        requestManager = GetComponent<PathRequestManager>();
    }

    private void Update()
    {
       
       //FindPath(seeker.position, target.position);
       
        
    }

    public void StartFindPath(Vector3 starPos, Vector3 targetPos)
    {
        StartCoroutine(FindPath(starPos, targetPos));
    }

    IEnumerator FindPath(Vector3 startPos, Vector3 targetPos)
    {
        //Stopwatch sw = new Stopwatch();
        //sw.Start();
        Vector3[] waypoints = new Vector3[0];
        bool pathSuccess = false;
        Node startNode = grid.NodeFromWorldPoint(startPos);
        Node targetNode = grid.NodeFromWorldPoint(targetPos);

        if(startNode.walkable && targetNode.walkable)
        {
            Heap<Node> openSet = new Heap<Node>(grid.MaxSize);
            HashSet<Node> closedSet = new HashSet<Node>();
            openSet.Add(startNode);

            while (openSet.Count > 0)
            {
                Node currentNode = openSet.RemoveFirst();
                closedSet.Add(currentNode);

                if (currentNode == targetNode)
                {
                    //sw.Stop();
                    //print("Path found: " + sw.ElapsedMilliseconds + " ms");
                    pathSuccess = true;
                    break;
                }

                foreach (Node neighbours in grid.GetNeighbours(currentNode))
                {
                    if (!neighbours.walkable || closedSet.Contains(neighbours))
                    {
                        continue;
                    }

                    int newMovementCostToNeighbours = currentNode.gCost + GetDistance(currentNode, neighbours);
                    if (newMovementCostToNeighbours < neighbours.gCost || !openSet.Contains(neighbours))
                    {
                        neighbours.gCost = newMovementCostToNeighbours;
                        neighbours.hCost = GetDistance(neighbours, targetNode);
                        neighbours.parent = currentNode;

                        if (!openSet.Contains(neighbours))
                        {
                            openSet.Add(neighbours);
                        }
                    }

                }

            }
        }
        
        yield return null;
        if (pathSuccess)
        {
            waypoints = RetracePath(startNode, targetNode); ;
        }
        requestManager.FinishedProcessingPath(waypoints, pathSuccess);
    }

    Vector3[] RetracePath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        while(currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        path.Add(startNode);
        Vector3[] waypoints = SimplifyPath(path);
        Array.Reverse(waypoints);
        return waypoints;
    }

    Vector3[] SimplifyPath(List<Node> path)
    {
        List<Vector3> waypoints = new List<Vector3>();
        Vector2 directionOld = Vector2.zero;
        for(int i =1; i < path.Count; i++)
        {
            Vector2 directionNew = new Vector2(path[i - 1].gridX - path[i].gridX, path[i - 1].gridY - path[i].gridY);
            if(directionNew != directionOld)
            {
                waypoints.Add(path[i - 1].worldPosition);
            }
            directionOld = directionNew;
        }
        return waypoints.ToArray();
    }

    int GetDistance(Node nodeA, Node nodeB)
    {
        int distX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int distY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        if(distX > distY)
            return 14 * distY + 10 * (distX - distY);
        return 14 * distX + 10 * (distY - distX);

    }
}
