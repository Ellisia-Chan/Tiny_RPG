using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI coinText;

    private void Awake() {
        coinText.text = "X 0";
    }

    private void OnEnable() {
        if (EventManager.Instance != null) {
            EventManager.Instance.coinEvents.OnCoinChange += UpdateCoinUI;
        }
    }

    private void OnDisable() {
        if (EventManager.Instance != null) {
            EventManager.Instance.coinEvents.OnCoinChange -= UpdateCoinUI;
        }
    }

    private void UpdateCoinUI(int coinValue) {
        coinText.text = $"X {coinValue}";
    }

}
