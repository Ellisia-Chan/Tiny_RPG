using UnityEngine;

public class Quest {
    // Static Info
    public QuestInfoSO questInfo;

    // State Info
    public QuestState questState;
    private int currentQuestStepIndex;

    public Quest(QuestInfoSO questInfo) {
        this.questInfo = questInfo;
        this.questState = QuestState.REQUIREMENTS_NOT_MET;
        this.currentQuestStepIndex = 0;
    }

    public void MoveToNextStep() {
        currentQuestStepIndex++;
    }

    public bool CurrentStepExist() {
        return (currentQuestStepIndex < questInfo.questStepsPrefabs.Length);
    }

    public void InstantiateCurrentQuestStep(Transform parentTransform) {
        GameObject questStepPrefab = GetCurrentQuestStepPrefab();

        if (questStepPrefab != null) {
            Object.Instantiate<GameObject>(questStepPrefab, parentTransform);
        }
    }

    private GameObject GetCurrentQuestStepPrefab() {
        GameObject questStepPrefab = null;

        if (CurrentStepExist()) {
            questStepPrefab = questInfo.questStepsPrefabs[currentQuestStepIndex];
        } else {
            Debug.LogWarning($"Tried to get quest step prefab when there is no more steps left. QuestID: {questInfo.id} StepIndex: {currentQuestStepIndex}");
        }

        return questStepPrefab;
    }
}
