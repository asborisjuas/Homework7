using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private int _coinsCollected = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isCollisionCoin = collision.TryGetComponent(out Coin coin);

        if (isCollisionCoin)
        {
            coin.Collect();
            _coinsCollected++;
        }
    }
}
