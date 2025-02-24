using UnityEngine;

public class Coin : MonoBehaviour {
    private CoinAnimator coinAnimator;
    private CircleCollider2D circleCollider2D;

    private int coinValue = 1;

    private void Awake() {
        coinAnimator = GetComponent<CoinAnimator>();
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<PlayerController>() != null) {
            CollectCoin();
        }
    }

    private void CollectCoin() {
        if (EventManager.Instance != null) {
            EventManager.Instance.coinEvents.CoinGained(coinValue);
            circleCollider2D.enabled = false;
            Destroy(gameObject);
        } else {
            Debug.LogWarning("Coin: EventManager Instance = null");
        }
    }
}
