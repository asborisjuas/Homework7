using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private SpawnCoinsPoint _parent;

    public void Init(SpawnCoinsPoint parent)
    {
        _parent = parent;
    }

    public void Collect()
    {
        _parent.Clear();
        Destroy(gameObject);
    }
}