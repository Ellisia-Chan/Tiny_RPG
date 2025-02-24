using System;

public class PlayerEvents {
    public event Action<int> OnPlayerLevelChange;

    public void PlayerLevelChange(int level) {
        OnPlayerLevelChange?.Invoke(level);
    }

    public void ClearEventSubs() {
        OnPlayerLevelChange = null;
    }
}
