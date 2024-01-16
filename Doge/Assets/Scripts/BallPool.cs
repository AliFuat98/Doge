using UnityEngine;

public class BallPool : MonoBehaviour {
  [SerializeField] PoolManagerSO poolManager;

  private void Start() {
    poolManager.InitializePool(transform);

    // first ball
    poolManager.GetObject();
  }
}