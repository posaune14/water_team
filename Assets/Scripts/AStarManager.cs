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
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
