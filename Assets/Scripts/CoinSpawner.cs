using System.Linq;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _prefab;

    private SpawnCoinsPoint[] _spawnPoints;

    private void Awake()
    {
        _spawnPoints = GetComponentsInChildren<SpawnCoinsPoint>();
    }

    private void OnEnable()
    {
        SpawnCoinsPoint.Despawned += Spawn;
    }
    private void OnDisable()
    {
        SpawnCoinsPoint.Despawned -= Spawn;
    }

    private void Start()
    {
        Spawn();
        Spawn();
    }

    public void Spawn()
    {
        var freePoints = _spawnPoints.Where(point => point.IsFree).ToArray();
        int randomIndex = Random.Range(0, freePoints.Length);

        freePoints[randomIndex].Spawn(_prefab);
    }
}
