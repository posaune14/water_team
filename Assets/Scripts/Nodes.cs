using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodes : MonoBehaviour
{
    public Nodes cameFrom; //position where the npc sprite "came from" 
    public List<Nodes> connections; // possible options for movement - surrounding connecting nodes that are directly reachable
    

    public float gScore; //distance from starting node to current node 
    public float hScore; //estimated distance from current node to goal destination

    public float FScore()
    {
        return gScore+hScore;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
