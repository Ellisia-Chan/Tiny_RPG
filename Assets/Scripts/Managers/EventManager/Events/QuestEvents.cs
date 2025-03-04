using System;

public class QuestEvents {
    public event Action<string> OnStartQuest;
    public event Action<string> OnAdvanceQuest;
    public event Action<string> OnFinishQuest;
    public event Action<Quest> OnQuestStateChange;

    public void StartQuest(string id) {
        OnStartQuest?.Invoke(id);
    }

    public void AdvanceQuest(string id) {
        OnAdvanceQuest?.Invoke(id);
    }

    public void FinishQuest(string id) {
        OnFinishQuest?.Invoke(id);
    }

    public void QuestStateChange(Quest quest) {
        OnQuestStateChange?.Invoke(quest);
    }

    public void ClearEventSubs() {
        OnStartQuest = null;
        OnAdvanceQuest = null;
        OnFinishQuest = null;
        OnQuestStateChange = null;
    }
}
