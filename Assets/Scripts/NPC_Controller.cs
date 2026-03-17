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
    
    public Node currentNode;
    public List<Node> path;

    public PlayerController player;
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

        if (playerSeen == false && currentState != StateMachine.Patrol && curHealth > (maxHealth*20)/100))
        {
            currentState = StateMachine.Patrol;
            path.Clear();
        }
        else if (playerSeen == true && currentState != StateMachine.Engage && curHealth > (maxHealth*20)/100))
        {
            currentState = StateMachine.Engage;
            path.Clear();
        }
        else if (currentState != StateMachine.Evade && curHealth <= (maxHealth*20)/100))
        {
            currentState = StateMachine.Evade;
            path.Clear();
        }
    }

    void Patrol()
    {
        
    }

    void Engage()
    {
        
    }

    void Evade()
    {
        
    }

    void createPath()
    {
        
    }
}