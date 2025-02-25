using UnityEngine;

public class CollectCoinsQuestStep : QuestStep {
    private int coinsCollected = 0;
    private int coinsToComplete = 5;

    private void OnEnable() {
        EventManager.Instance.miscEvents.onCoinCollected += CoinCollected;
    }

    private void OnDisable() {
        EventManager.Instance.miscEvents.onCoinCollected -= CoinCollected;
    }

    private void CoinCollected() {
        if (coinsCollected < coinsToComplete) {
            coinsCollected++;
        }

        if (coinsCollected >= coinsToComplete) {
            FinishQuestStep();
        }
    }
}
