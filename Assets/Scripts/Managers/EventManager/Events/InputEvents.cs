using System;

public class InputEvents {
    public event Action OnRunAction;
    public event Action OnRunActionCancel;

    public void RunAction() => OnRunAction?.Invoke();
    public void RunActionCancel() => OnRunActionCancel?.Invoke();

    public void ClearEventSubs() {
        OnRunAction = null;
        OnRunActionCancel = null;
    }
}
