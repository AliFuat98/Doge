using System;
using UnityEngine;

public class GameInput : MonoBehaviour {
  public static GameInput Instance { get; private set; }

  private PlayerInputActions playerInputActions;

  public event EventHandler OnChainAction;

  private void Awake() {
    Instance = this;

    playerInputActions = new PlayerInputActions();
    playerInputActions.Player.Enable();

    playerInputActions.Player.Chain.performed += Chain_performed;
  }

  private void Chain_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
    OnChainAction?.Invoke(this, EventArgs.Empty);
  }

  public float GetMovementAxis() {
    float inputVector = playerInputActions.Player.Move.ReadValue<float>();
    return inputVector;
  }

  private void OnDestroy() {
    playerInputActions.Player.Move.performed -= Chain_performed;
    playerInputActions.Dispose();
  }
}