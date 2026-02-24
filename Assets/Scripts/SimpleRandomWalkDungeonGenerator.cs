using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SimpleRandomWalkMapGenerator: AbstractDungeonGenerator
{
    [SerializeField] 
    private int iterations = 10;
    [SerializeField] 
    public int walkLength = 10;
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
        foreach (var position in positions)
        {
            start = new Vector3Int(position.x, position.y, 0);
            break;
        }
        
        Instantiate(player, start, Quaternion.identity);

    }
}
