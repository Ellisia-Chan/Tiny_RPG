using UnityEngine;

public class CoinAnimator : MonoBehaviour {
    private const string COIN_PICKUP = "CoinPickup";

    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public void PlayCoinPickup() {
        animator.SetTrigger(COIN_PICKUP);
    }

    public void DestroyCoin() {
        Destroy(gameObject);
    }

    private void OnBecameInvisible() {
        animator.enabled = false;
    }

    private void OnBecameVisible() {
        animator.enabled = true;
    }
}
