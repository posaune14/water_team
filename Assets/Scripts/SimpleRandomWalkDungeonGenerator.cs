using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SimpleRandomWalkMapGenerator: AbstractDungeonGenerator
{
    [SerializeField] 
    private int iterations = 82;
    [SerializeField] 
    public int walkLength = 22;
    [SerializeField]
    public bool startRandomlyEachInteration = true;

    [SerializeField]
    public GameObject player;        
    
    private Vector3Int start;

    protected override void RunProceduralGeneration()
    {
        HashSet<Vector2Int> floorPositions = RunRandomWalk();
        tilemapVisualizer.Clear();
        tilemapVisualizer.PaintFloorTiles(floorPositions);
        WallGenerator.CreateWalls(floorPositions, tilemapVisualizer);
        SpawnPlayer(floorPositions);
        
    }

    protected HashSet<Vector2Int> RunRandomWalk()
    {
        var currentPosition = startPosition;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        for (int i = 0; i < iterations; i++)
        {
            var path = ProceduralGenerationAlgorithms.SimpleRandomWalk(currentPosition, walkLength);
            floorPositions.UnionWith(path);
            if (startRandomlyEachInteration)
                currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
        }
        return floorPositions;
    }

    private void SpawnPlayer(HashSet<Vector2Int> positions)
    {
        /*
        //removing prior copies of prefab 
        GameObject clone = GameObject.Find("Player_1(Clone)");
        //if clone is the same as if(clone!=null)s
        if(clone)
            DestroyImmediate(clone);
        */
        //convert to list because otherwise always retrieves 0,0, even though hashset is theoretically unordered, 0,0
        //is first always
        Vector2Int[] coordinates = positions.ToArray();
        startPosition = coordinates[UnityEngine.Random.Range(0, coordinates.Length)];
        start = new Vector3Int(startPosition.x, startPosition.y, 0);
        player.transform.position = start;
    }
}
