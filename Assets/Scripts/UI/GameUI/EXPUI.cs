using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EXPUI : MonoBehaviour {

    [Header("UI Components")]
    [SerializeField] private Image progressBar;
    [SerializeField] private TextMeshProUGUI playerLevelText;
    [SerializeField] private TextMeshProUGUI playerEXPProgressText;

    private void Start() {
        progressBar.fillAmount = 0f;
        playerLevelText.text = "Level 1";
        playerEXPProgressText.text = "0 / 100";
    }

    private void OnEnable() {
        if (EventManager.Instance != null) {
            EventManager.Instance.expEvents.OnXPChange += UpdateEXPUI;
            EventManager.Instance.playerEvents.OnPlayerLevelChange += UpdatePlayerLevelUI;
        }
    }

    private void OnDisable() {
        if (EventManager.Instance != null) {
            EventManager.Instance.expEvents.OnXPChange -= UpdateEXPUI;
            EventManager.Instance.playerEvents.OnPlayerLevelChange -= UpdatePlayerLevelUI;
        }
    }

    private void UpdateEXPUI(int xpValue) {
        progressBar.fillAmount = xpValue / 100f;
        playerEXPProgressText.text = $"{xpValue} / 100";
    }

    private void UpdatePlayerLevelUI(int level) {
        playerLevelText.text = $"Level {level}";
    }
}
