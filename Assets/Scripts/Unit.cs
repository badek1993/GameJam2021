using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public Tile tile;
    int currentHP, maxHP;
    bool enemy;
    public virtual void TakeDamage(int amount)
    {
        currentHP -= amount;
        if(currentHP <= 0)
        {
            Kill();
        }
    }
    public virtual void Kill()
    {
        tile.unit = null;
        Destroy(gameObject);
    }
}
