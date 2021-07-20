using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public Tile[,] TileGrid;
    public Vector2Int GridSize;
    public GameObject TilesHolder;

    private void Start()
    {
        InitializeGrid();
    }

    private void Update()
    {
        
    }

    void InitializeGrid()
    {
        TileGrid = new Tile[GridSize.x, GridSize.y];
        FindTiles();
    }

    void FindTiles()
    {
        foreach (Tile tile in TilesHolder.GetComponentsInChildren<Tile>())
        {
            tile.FindGridPos();
            Vector2Int tileGridPos = tile.gridPos;
            TileGrid[tileGridPos.x, tileGridPos.y] = tile;
        }
    }

    Tile[] PathFinding(Vector2Int startPos, int range)
    {
        List<Tile> visitedTiles = new List<Tile>();

        Queue<Tile> tilesToVisit = new Queue<Tile>();
        tilesToVisit.Enqueue(TileGrid[startPos.x, startPos.y]);
        tilesToVisit.Peek().pathFindingRange = range;
        tilesToVisit.Peek().visited = true;

        while(tilesToVisit.Count > 0)
        {
            Debug.Log("xd");
            visitedTiles.Add(tilesToVisit.Peek());

            if (tilesToVisit.Peek().pathFindingRange == 0)
            {
                tilesToVisit.Dequeue();
                continue;
            }

            Tile[] newTiles = FindNeighbours(tilesToVisit.Peek().gridPos);
            foreach (Tile newTile in newTiles)
            {
                if (newTile.obstacle || newTile.visited)
                    continue;

                newTile.visited = true;
                newTile.pathFindingRange = tilesToVisit.Peek().pathFindingRange - 1;
                tilesToVisit.Enqueue(newTile);
            }

            tilesToVisit.Dequeue();
        }

        return visitedTiles.ToArray();
    }

    Tile[] FindNeighbours (Vector2Int tilePos)
    {
        List<Tile> Tiles = new List<Tile>();

        if (tilePos.x - 1 >= 0)
            Tiles.Add(TileGrid[tilePos.x - 1, tilePos.y]);
        if (tilePos.x + 1 < GridSize.x)
            Tiles.Add(TileGrid[tilePos.x + 1, tilePos.y]);
        if (tilePos.y - 1 >= 0)
            Tiles.Add(TileGrid[tilePos.x, tilePos.y - 1]);
        if (tilePos.y + 1 < GridSize.y)
            Tiles.Add(TileGrid[tilePos.x, tilePos.y + 1]);

        return Tiles.ToArray();
    }

    public bool DoesTileExist(Vector2 pos)
    {
        if (pos.x < 0 || pos.x >= GridSize.x)
            return false;
        if (pos.y < 0 || pos.y >= GridSize.y)
            return false;
        return true;
    }
}
