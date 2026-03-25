using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;


public class NPC_Controller : MonoBehaviour
{
    public int maxHealth = 100;
    public int curHealth;
    public int panicMultiplier = 1;
    
    public Nodes currentNode;
    public List<Nodes> path = new List<Nodes>();

    public GameObject player;
    public float speed = 3;

    public enum StateMachine
    {
        Patrol,
        Engage,
        Evade
    }

    public StateMachine currentState;

    private void Start()
    {
        currentState = StateMachine.Patrol;
    }

    private void Update()
    {
        switch (currentState)
        {
            case StateMachine.Patrol:
                Debug.Log(path);
                Patrol();

                break;
            case StateMachine.Engage:
                Engage();
                break;
            case StateMachine.Evade:
                Evade();
                break;
        }

        bool playerSeen = Vector2.Distance(transform.position, player.transform.position) < 5.0f;

        if (playerSeen == false && currentState != StateMachine.Patrol && curHealth > (maxHealth*20)/100)
        {
            currentState = StateMachine.Patrol;
            path.Clear();
        }
        else if (playerSeen == true && currentState != StateMachine.Engage && curHealth > (maxHealth*20)/100)
        {
            currentState = StateMachine.Engage;
            path.Clear();
        }
        else if (currentState != StateMachine.Evade && curHealth <= (maxHealth*20)/100)
        {
            currentState = StateMachine.Evade;
            path.Clear();
        }
        //function below
        CreatePath();
    }

    void Patrol()
    {   
        if(path.Count==0)
        {
            path = AStarManager.instance.GenerationPath(currentNode, AStarManager.instance.AllNodes()[Random.Range(0, AStarManager.instance.AllNodes().Length)]);
            //Debug.Log(path);
        }
    }   

    void Engage()
    {
        if(path.Count ==0)
        {
            path = AStarManager.instance.GenerationPath(currentNode, AStarManager.instance.FindNearestNode(player.transform.position));
            //Debug.Log(path);
        }
    }

    void Evade()
    {
        if(path.Count==0)
        {
            path = AStarManager.instance.GenerationPath(currentNode, AStarManager.instance.FindFurthestNode(player.transform.position));
            //Debug.Log(path);
        }
    }

    //create path from npc to player
    void CreatePath()
    {
        if(path.Count>0)
        {
            int x = 0;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(path[x].transform.position.x, path[x].transform.position.y, -2), speed * Time.deltaTime);

            if (Vector2.Distance(transform.position,path[x].transform.position) < 0.1f)
            {
                currentNode = path[x];
                path.RemoveAt(x);
            }
        }
    }
}