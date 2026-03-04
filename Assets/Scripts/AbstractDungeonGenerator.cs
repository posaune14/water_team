using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;

public abstract class AbstractDungeonGenerator : MonoBehaviour
{
    //Serialize field makes it show up when clicked in unity
    [SerializeField] protected TilemapVisualizer tilemapVisualizer = null;
    [SerializeField] protected Vector2Int startPosition;

    public void GenerateDungeon()
    {
        startPosition = Vector2Int.zero;
        tilemapVisualizer.Clear();
        RunProceduralGeneration();
    }
    
    protected abstract void RunProceduralGeneration();
}
