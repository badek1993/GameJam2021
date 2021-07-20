using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool obstacle;
    public Unit unit;
    public bool visited;
    public Vector2Int gridPos;
    public int pathFindingRange;
    private void Start()
    {
    }

    public void FindGridPos()
    {
        visited = false;
        gridPos.x = (int)transform.position.x / 2;
        gridPos.y = (int)transform.position.z / 2;
    }
}
