using System;
using Unity.VisualScripting;
using UnityEngine;
    
public class GameControl: SimpleRandomWalkMapGenerator
{
    private int enemies = 0;

    public void Start()
    {
        if (enemies == 0)
        {
            GenerateDungeon();
        }
    }
    public void Update()
    {
        
    }
}