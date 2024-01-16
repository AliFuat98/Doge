using UnityEngine;

public class GameInput : MonoBehaviour {
  public static GameInput Instance { get; private set; }

  private PlayerInputActions playerInputActions;

  //public event EventHandler OnJumpAction;

  private void Awake() {
    Instance = this;

    playerInputActions = new PlayerInputActions();
    playerInputActions.Player.Enable();

    //playerInputActions.Player.Move.performed += Move_performed;
  }

  //public void Move_performed(InputAction.CallbackContext context) {
  //  OnJumpAction?.Invoke(this, EventArgs.Empty);
  //}

  public float GetMovementAxis() {
    float inputVector = playerInputActions.Player.Move.ReadValue<float>();
    return inputVector;
  }

  private void OnDestroy() {
    //playerInputActions.Player.Move.performed -= Move_performed;
    playerInputActions.Dispose();
  }
}