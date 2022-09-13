using System;
using UnityEngine;

public class SpawnCoinsPoint : MonoBehaviour
{
    public bool IsFree { get; private set; } = true;

    public static event Action Despawned;

    public void Spawn(Coin prefab)
    {
        IsFree = false;
        var coin = Instantiate(prefab, transform.position, Quaternion.identity, transform);
        coin.Init(this);
    }

    public void Clear()
    {
        IsFree = true;
        Despawned?.Invoke();
    }
}
