using UnityEngine;
using UnityEngine.InputSystem;

public class GameInputManager : MonoBehaviour {
    public static GameInputManager Instance { get; private set; }

    private PlayerInputActions playerInputActions;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Debug.LogError("GameInputManager: Instance already exists");
            Destroy(gameObject);
        }
        playerInputActions = new PlayerInputActions();
    }


    private void OnEnable() {
        playerInputActions.Enable();

        playerInputActions.Player.Run.performed += RunAction;
        playerInputActions.Player.Run.canceled += RunActionCancel;
        playerInputActions.Player.Submit.performed += SubmitAction;
    }

    private void OnDisable() {
        playerInputActions.Disable();

        playerInputActions.Player.Run.performed -= RunAction;
        playerInputActions.Player.Run.canceled -= RunActionCancel;
        playerInputActions.Player.Submit.performed -= SubmitAction;
    }

    private void RunAction(InputAction.CallbackContext obj) {
        EventManager.Instance.inputEvents.RunAction();
    }

    private void RunActionCancel(InputAction.CallbackContext obj) {
        EventManager.Instance.inputEvents.RunActionCancel();
    }

    private void SubmitAction(InputAction.CallbackContext obj) {
        EventManager.Instance.inputEvents.SubmitAction();
    }

    public Vector2 GetMovementVectorNormalized() {
        return playerInputActions.Player.Movement.ReadValue<Vector2>().normalized;
    }
}
