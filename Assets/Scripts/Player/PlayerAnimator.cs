using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

    private const string IS_MOVING = "isMoving";
    private const string X_DIR = "X_Dir";
    private const string Y_DIR = "Y_Dir";

    private Animator animator;
    private PlayerMovement playerMovement;
    private Vector2 moveDir;
    private Vector2 lastMoveDir;

    private void Awake() {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update() {
        if (animator != null && playerMovement != null) {
            moveDir = playerMovement.GetMovementDir();

            if (moveDir != Vector2.zero) {
                lastMoveDir = moveDir;
            }

            animator.SetBool(IS_MOVING, moveDir != Vector2.zero);
            animator.SetFloat(X_DIR, lastMoveDir.x);
            animator.SetFloat(Y_DIR, lastMoveDir.y);
        }
    }
}
