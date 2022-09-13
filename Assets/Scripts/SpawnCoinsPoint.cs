using System;
using UnityEngine;

public class SpawnCoinsPoint : MonoBehaviour
{
    private Transform _transform;

    public bool IsFree { get; private set; } = true;

    public static event Action Despawned;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    public void Spawn(Coin prefab)
    {
        IsFree = false;
        var coin = Instantiate(prefab, _transform.position, Quaternion.identity, _transform);
        coin.Init(this);
    }

    public void Clear()
    {
        IsFree = true;
        Despawned?.Invoke();
    }
}
