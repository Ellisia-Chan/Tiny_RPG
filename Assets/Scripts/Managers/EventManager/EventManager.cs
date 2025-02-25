using System;
using UnityEngine;

public class EventManager : MonoBehaviour {
    public static EventManager Instance { get; private set; }

    //Input Events
    public InputEvents inputEvents { get; private set; }

    //UI Events
    public GameUIEvents gameUIEvents { get; private set; }

    //Player Events
    public PlayerEvents playerEvents { get; private set; }

    // Other Events
    public CoinEvents coinEvents { get; private set; }
    public EXPEvents expEvents { get; private set; }

    //Misc
    public MiscEvents miscEvents { get; private set; }

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            InitializeEvents();
        } else {
            Debug.LogError("GameEventManager: Instance already exists");
            Destroy(gameObject);
        }
    }

    private void InitializeEvents() {
        playerEvents = new PlayerEvents();
        inputEvents = new InputEvents();
        gameUIEvents = new GameUIEvents();
        coinEvents = new CoinEvents();
        expEvents = new EXPEvents();
        miscEvents = new MiscEvents();
    }

    private void UnsubscribeEvents() {
        playerEvents?.ClearEventSubs();
        inputEvents?.ClearEventSubs();
        gameUIEvents?.ClearEventSubs();
        coinEvents?.ClearEventSubs();
        expEvents?.ClearEventSubs();
        miscEvents?.ClearEventSubs();
    }

    private void OnDestroy() {
        if (Instance == this) {
            UnsubscribeEvents();
            Instance = null;
        }
    }
}
