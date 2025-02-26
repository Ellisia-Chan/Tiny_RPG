using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {
    private Dictionary<string, Quest> questMap;

    private void Awake() {
        questMap = CreateQuestMap();
    }

    private void OnEnable() {
        EventManager.Instance.questEvents.OnStartQuest += StartQuest;
        EventManager.Instance.questEvents.OnAdvanceQuest += AdvanceQuest;
        EventManager.Instance.questEvents.OnFinishQuest += FinishQuest;
    }

    private void OnDisable() {
        EventManager.Instance.questEvents.OnStartQuest -= StartQuest;
        EventManager.Instance.questEvents.OnAdvanceQuest -= AdvanceQuest;
        EventManager.Instance.questEvents.OnFinishQuest -= FinishQuest;
    }

    private void Start() {
        // Broadcast the initial state of all quests on start
        foreach (Quest quest in questMap.Values) {
            EventManager.Instance.questEvents.QuestStateChange(quest);
        }
    }

    private void StartQuest(string id) {
        Debug.Log("Start Quest: " + id);
    }

    private void AdvanceQuest(string id) {
        Debug.Log("Advance Quest: " + id);
    }

    private void FinishQuest(string id) {
        Debug.Log("Finish Quest: " + id);
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
