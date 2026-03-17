using System;
using Unity.VisualScripting;
using UnityEngine;
    
public class GameControl: SimpleRandomWalkMapGenerator
{
    private int enemies = 1;

    public void Update()
    {
        if (enemies == 0)
        {
            GenerateDungeon();
        }
    }
}