using UnityEngine;

public class PlayerStatsManager : MonoBehaviour {
    public static PlayerStatsManager Instance { get; private set; }

    private int collectedCoins = 0;
    private int collectedXP = 0;

    private int playerLevel = 1;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Debug.LogError("PlayerStatsManager: Instance already exists");
            Destroy(gameObject);
        }
    }

    private void OnEnable() {
        EventManager.Instance.coinEvents.OnCoinGained += AddCoin;
        EventManager.Instance.expEvents.OnXPGained += AddXP;
    }

    private void OnDisable() {
        EventManager.Instance.coinEvents.OnCoinGained -= AddCoin;
        EventManager.Instance.expEvents.OnXPGained -= AddXP;
    }

    private void AddCoin(int coinValue) {
        collectedCoins += coinValue;
        EventManager.Instance.coinEvents.CoinChange(collectedCoins);
    }

    private void AddXP(int xpValue) {
        collectedXP += xpValue;

        if (collectedXP == 100) {
            playerLevel++;
            collectedXP = 0;

            EventManager.Instance.playerEvents.PlayerLevelChange(playerLevel);
        }

        EventManager.Instance.expEvents.XPChange(collectedXP);
    }
}
