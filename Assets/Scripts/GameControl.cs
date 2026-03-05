using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameControl: SimpleRandomWalkMapGenerator
{
    public int enemies = 0;
    public void Update()
    {
        if (enemies == 0)
        {
            GenerateDungeon();
        }
    }
}