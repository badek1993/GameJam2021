using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalState : TurnState
{
    public TurnManager turnManager;
    Tile mouseTile = null;
    public override void UpdateState()
    {
        UpdateMouseTile();

    }

    private void UpdateMouseTile()
    {
        Tile newMouseTile = turnManager.GetMouseTile();
        if (mouseTile != newMouseTile)
        {
            if (newMouseTile != null)
            {
                newMouseTile.GetComponent<MeshRenderer>().material.color = Color.red;
            }
            if (mouseTile != null)
            {
                mouseTile.GetComponent<MeshRenderer>().material.color = Color.white;
            }
        }
        mouseTile = newMouseTile;
    }
}
