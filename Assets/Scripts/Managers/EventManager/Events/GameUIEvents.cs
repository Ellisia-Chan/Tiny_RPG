using System;

public class GameUIEvents {
    public event Action OnUpdateCoinUI;

    public void UpdateCoinUI() {
        OnUpdateCoinUI?.Invoke();
    }

    public void ClearEventSubs() {
        OnUpdateCoinUI = null;
    }
}
