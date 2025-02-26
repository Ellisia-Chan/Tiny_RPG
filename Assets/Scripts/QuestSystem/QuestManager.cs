using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {
    private Dictionary<string, Quest> questMap;

    private void Awake() {
        questMap = CreateQuestMap();

        Quest quest = GetQuestById("CollectCoinQuest");
        Debug.Log(quest.questInfo.id);
        Debug.Log(quest.questInfo.displayName);
        Debug.Log(quest.questInfo.levelRequirement);
        Debug.Log(quest.questState);
        Debug.Log(quest.CurrentStepExist());
    }

    private Dictionary<string, Quest> CreateQuestMap() {
        QuestInfoSO[] allQuests = Resources.LoadAll<QuestInfoSO>("Quest");

        Dictionary<string, Quest> idToQuestMap = new Dictionary<string, Quest>();
        foreach (QuestInfoSO questInfo in allQuests) {
            if (idToQuestMap.ContainsKey(questInfo.id)) {
                Debug.LogError($"Duplicate quest id: {questInfo.id} in {questInfo.name} and {idToQuestMap[questInfo.id].questInfo.name}.");
            }
            idToQuestMap.Add(questInfo.id, new Quest(questInfo));
        }
        return idToQuestMap;
    }

    private Quest GetQuestById(string id) {
        Quest quest = questMap[id];

        if (quest == null) {
            Debug.LogError($"Tried to get a quest with id {id} but there is no quest with that id");
        }

        return quest;
    }
}
