using System;

public class EXPEvents {
    public event Action<int> OnXPGained;
    public event Action<int> OnXPChange;

    public void XPGained(int xpValue) {
        OnXPGained?.Invoke(xpValue);
    }

    public void XPChange(int xpValue) {
        OnXPChange?.Invoke(xpValue);
    }

    public void ClearEventSubs() {
        OnXPGained = null;
        OnXPChange = null;
    }
}
