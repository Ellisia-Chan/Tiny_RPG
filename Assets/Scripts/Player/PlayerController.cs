using UnityEngine;

public class PlayerController : MonoBehaviour {
    public static PlayerController Instance { get; private set; }

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Debug.LogError("PlayerController: Instance Already Exists.");
            Destroy(gameObject);
        }
    }
}
