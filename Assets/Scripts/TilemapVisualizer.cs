using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;
using System.Collections;
using System;

public class TilemapVisualizer : MonoBehaviour
{
    [SerializeField]
    private Tilemap floorTilemap, wallTileMap;
    [SerializeField]
    private TileBase floorTile, wallTop;
    public Nodes node_prefab;
    

    public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions)
    {
        PaintTiles(floorPositions, floorTilemap, floorTile);
    }

    private void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile)
    {
        foreach (var position in positions)
        {
            PaintSingleTile(tilemap, tile, position);
            Nodes node = Instantiate(node_prefab, new Vector3(position.x, position.y, 0), Quaternion.identity);
        }
    }

    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
    {
        var tilePosition = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tilePosition, tile);
    }

    internal void PaintSingleBasicWall(Vector2Int position)
    {
        PaintSingleTile(wallTileMap, wallTop, position);
    }

    public void Clear()
    {
        floorTilemap.ClearAllTiles();
        wallTileMap.ClearAllTiles();
    }
}
