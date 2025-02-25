using System;

public class MiscEvents {
    public event Action onCoinCollected;
    public event Action onEXPCollected;

    public void CoinCollected() => onCoinCollected?.Invoke();
    public void EXPCollected() => onEXPCollected?.Invoke();

    public void ClearEventSubs() {
        onCoinCollected = null;
        onEXPCollected = null;
    }
}
