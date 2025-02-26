using System;

public class InputEvents {
    public event Action OnRunAction;
    public event Action OnRunActionCancel;
    public event Action OnSubmitAction;

    public void RunAction() => OnRunAction?.Invoke();
    public void RunActionCancel() => OnRunActionCancel?.Invoke();
    public void SubmitAction() => OnSubmitAction?.Invoke();

    public void ClearEventSubs() {
        OnRunAction = null;
        OnRunActionCancel = null;
        OnSubmitAction = null;
    }
}
