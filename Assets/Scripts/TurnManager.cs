using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public GridController gridController;
    public TurnState 
        normalState = new NormalState(), 
        unitState,
        infoState;
    public TurnState currentState;

    private void Start()
    {
        currentState = normalState;
    }

    void Update()
    {
        currentState.UpdateState();
    }

    public Tile GetMouseTile()
    {
        Vector3 l = Camera.main.ScreenPointToRay(Input.mousePosition).direction.normalized;
        Vector3 l0 = -Camera.main.transform.position;
        Vector3 n = new Vector3(0, 1, 0);
        float d = Vector3.Dot(l0, n) / Vector3.Dot(l, n);
        Vector3 TileWorldPos = ((-l0 + l * d) + new Vector3(1, 0, 1))/2f;
        if (TileWorldPos.x < 0 || TileWorldPos.z < 0)
            return null;
        Vector2Int TilePos = new Vector2Int((int)TileWorldPos.x, (int)TileWorldPos.z);
        if(gridController.DoesTileExist(TilePos))
            return gridController.TileGrid[TilePos.x, TilePos.y];
        return null;
    }
}
