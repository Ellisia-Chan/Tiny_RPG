using UnityEngine;

public class GameSettings : MonoBehaviour {
    [SerializeField] private int targetFrameRate = 60;

    private void Start() {
        Application.targetFrameRate = targetFrameRate;
    }
}
