using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float runSpeed = 10f;

    private Rigidbody2D rb;
    private Vector2 movement;

    private float defaultMoveSpeed;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null) { Debug.LogWarning("PlayerMovement: Missing Rigidbody2D"); }

        defaultMoveSpeed = moveSpeed;
    }

    private void OnEnable() {
        if (EventManager.Instance != null) {
            EventManager.Instance.inputEvents.OnRunAction += StartRunAction;
            EventManager.Instance.inputEvents.OnRunActionCancel += StopRunAction;
        }
    }

    private void OnDisable() {
        if (EventManager.Instance != null) {
            EventManager.Instance.inputEvents.OnRunAction -= StartRunAction;
            EventManager.Instance.inputEvents.OnRunActionCancel -= StopRunAction;
        }
    }

    private void Update() {
        HandlePlayerInput();
    }

    private void FixedUpdate() {
        HandlePlayerMovement();
    }

    private void HandlePlayerInput() {
        if (GameInputManager.Instance != null) {
            movement = GameInputManager.Instance.GetMovementVectorNormalized();
        }
    }

    private void HandlePlayerMovement() {
        if (rb != null) {
            rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
        }
    }

    private void StartRunAction() {
        moveSpeed = runSpeed;
    }

    private void StopRunAction() {
        moveSpeed = defaultMoveSpeed;
    }

    public Vector2 GetMovementDir() {
        return movement;
    }
}
