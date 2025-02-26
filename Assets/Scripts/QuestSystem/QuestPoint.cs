using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class QuestPoint : MonoBehaviour {
    [Header("Quest Point Settings")]
    [SerializeField] private QuestInfoSO questInfoForPoint;

    [Header("Config")]
    [SerializeField] private bool startPoint = true;
    [SerializeField] private bool finishPoint = false;

    private bool playerIsNear = false;
    private string questId;
    private QuestState currentQuestState;

    private void Awake() {
        questId = questInfoForPoint.id;
    }

    private void OnEnable() {
        if (EventManager.Instance != null) {
            EventManager.Instance.questEvents.OnQuestStateChange += QuestStateChange;
            EventManager.Instance.inputEvents.OnSubmitAction += SubmitAction; 
        }
    }

    private void OnDisable() {
        if (EventManager.Instance != null) {
            EventManager.Instance.questEvents.OnQuestStateChange -= QuestStateChange;
            EventManager.Instance.inputEvents.OnSubmitAction -= SubmitAction; 
        }
    }

    private void SubmitAction() {
        if (!playerIsNear) return;

        if (currentQuestState.Equals(QuestState.CAN_START) && startPoint) {
            EventManager.Instance.questEvents.StartQuest(questId);

        } else if (currentQuestState.Equals(QuestState.CAN_FINISH) && finishPoint) {
            EventManager.Instance.questEvents.FinishQuest(questId);
        }
    }

    private void QuestStateChange(Quest quest) {
        if (quest.questInfo.id.Equals(questId)) {
            currentQuestState = quest.questState;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<PlayerController>() != null) {
            playerIsNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<PlayerController>() != null) {
            playerIsNear = false;
        }
    }
}
