﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Node startNode = grid.NodeFromWorldPoint(startPos);
        Node targetNode = grid.NodeFromWorldPoint(targetPos);

        List<Node> openSet = new List<Node>();
        HashSet<Node> closedSet = new HashSet<Node>();
        openSet.Add(startNode);

        while(openSet.Count > 0)
        {
            Node currentNode = openSet[0];
            for(int i = 1; i < openSet.Count; i++)
            {
                if(openSet[i].FCost < currentNode.FCost || openSet[i].FCost == currentNode.FCost && openSet[i].hCost < currentNode.hCost)
                {
                    currentNode = openSet[i];
                }
            }
            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            if(currentNode == targetNode)
            {
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