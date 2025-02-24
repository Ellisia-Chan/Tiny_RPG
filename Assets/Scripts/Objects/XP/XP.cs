using UnityEngine;

public class XP : MonoBehaviour {
    private CircleCollider2D circleCollider2D;

    private int xpValue = 20;

    private void Awake() {
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<PlayerController>() != null) {
            CollectXP();
        }
    }

    private void CollectXP() {
        EventManager.Instance.expEvents.XPGained(xpValue);
        circleCollider2D.enabled = false;
        Destroy(gameObject);
    }
}
