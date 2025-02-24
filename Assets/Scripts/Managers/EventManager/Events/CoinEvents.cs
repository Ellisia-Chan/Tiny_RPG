using System;

public class CoinEvents {
    public event Action<int> OnCoinGained;
    public event Action<int> OnCoinChange;

    public void CoinGained(int coinValue) {
        OnCoinGained?.Invoke(coinValue);
    }
    public void CoinChange(int coinValue) {
        OnCoinChange?.Invoke(coinValue);
    }

    public void ClearEventSubs() {
        OnCoinGained = null;
        OnCoinChange = null;
    }
}
