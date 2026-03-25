using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarManager : MonoBehaviour
{
    
    public static AStarManager instance;

    private void Awake()
    {
        instance = this;
    }

    public List<Nodes> GenerationPath(Nodes start, Nodes end)

    {
        List<Nodes> openSet = new List<Nodes>();        

        foreach(Nodes n in FindObjectsOfType<Nodes>())
        {
            n.gScore = float.MaxValue;
        }

        start.gScore = 0;
        start.hScore = Vector2.Distance(start.transform.position, end.transform.position);
        
        while(openSet.Count>0)
        {
            int lowestF = default;
            for(int i=1; i< openSet.Count; i++)
            {
                if (openSet[i].FScore() <openSet[lowestF].FScore())
                {
                    lowestF = i;
                }
            }
            Nodes currentNode = openSet[lowestF];
            openSet.Remove(currentNode);

            if (currentNode== end)
            {
                List<Nodes> path = new List<Nodes>();
                
                path.Insert(0, end);

                while (currentNode != start) 
                {
                    currentNode = currentNode.cameFrom;
                    path.Add(currentNode);
                }

                path.Reverse();
                return path;

            }

            foreach(Nodes connectedNode in currentNode.connections)
            {
                float heldGScore = currentNode.gScore + Vector2.Distance(currentNode.transform.position, connectedNode.transform.position);
                if(heldGScore<connectedNode.gScore)
                {
                    connectedNode.cameFrom = currentNode;
                    connectedNode.gScore = heldGScore;
                    connectedNode.hScore = Vector2.Distance(connectedNode.transform.position,end.transform.position); 
                    if (!openSet.Contains(connectedNode))
                    {
                        openSet.Add(connectedNode);
                    }

                }
            }
        
        }
        return null;
    } 
    public Nodes FindNearestNode(Vector2 pos)
    {
        Nodes foundNode = null;
        float minDistance = float.MaxValue;

        foreach(Nodes node in FindObjectsOfType<Nodes>())
        {
            float currentDistance = Vector2.Distance(pos, node.transform.position);

            if(currentDistance < minDistance)
            {
                minDistance = currentDistance;
                foundNode = node;
            }
        }

        return foundNode;
    }

    public Nodes FindFurthestNode(Vector2 pos)
    {
        Nodes foundNode = null;
        float maxDistance = default;

        foreach (Nodes node in FindObjectsOfType<Nodes>())
        {
            float currentDistance = Vector2.Distance(pos, node.transform.position);
            if(currentDistance > maxDistance)
            {
                maxDistance = currentDistance;
                foundNode = node;
            }
        }

        return foundNode;
    }

    public Nodes[] AllNodes()
    {
        return FindObjectsOfType<Nodes>();
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
