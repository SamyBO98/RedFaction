using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class Pathfinding : MonoBehaviour
{
    GridAStar grid;
    public Transform seeker, target;

     void Awake()
    {
        grid = GetComponent<GridAStar>();
    }

    private void Update()
    {
     
      FindPath(seeker.position, target.position);
      
        
    }
    void FindPath(Vector3 startPos, Vector3 targetPos)
    {
        //Stopwatch sw = new Stopwatch();
        //sw.Start();
        Node startNode = grid.NodeFromWorldPoint(startPos);
        Node targetNode = grid.NodeFromWorldPoint(targetPos);

        Heap<Node> openSet = new Heap<Node>(grid.MaxSize);
        HashSet<Node> closedSet = new HashSet<Node>();
        openSet.Add(startNode);

        while(openSet.Count > 0)
        {
            Node currentNode = openSet.RemoveFirst();
            closedSet.Add(currentNode);

            if(currentNode == targetNode)
            {
                //sw.Stop();
               // print("Path Found: " + sw.ElapsedMilliseconds + " ms");
                TracePath(startNode, targetNode);
                return;
            }

            foreach (Node neighbours in grid.GetNeighbours(currentNode)){
                if(!neighbours.walkable || closedSet.Contains(neighbours))
                {
                    continue;
                }

                int newMovCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbours);
                if(newMovCostToNeighbour < neighbours.gCost || !openSet.Contains(neighbours))
                {
                    neighbours.gCost = newMovCostToNeighbour;
                    neighbours.hCost = GetDistance(neighbours, targetNode);
                    neighbours.parent = currentNode;

                    if (!openSet.Contains(neighbours))
                        openSet.Add(neighbours);
                }
            }
        }
    }

    void TracePath(Node starNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        while (currentNode != starNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }

        path.Reverse();

        grid.path = path;
    }

    int GetDistance(Node nodeA, Node nodeB)
    {
        int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        if (dstX > dstY)
            return 14 * dstY + 10 * (dstX - dstY);
        return 14 * dstX + 10 * (dstY - dstX);
    }
}
