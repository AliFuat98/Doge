using UnityEngine;

public class BallSplit : MonoBehaviour {
  [SerializeField] PoolManagerSO BallPoolSO;

  [SerializeField] BallSO currentBallSO;

  void Update() {
    if (Input.GetKeyDown(KeyCode.Space)) {
      Split();
    }
  }

  void Split() {
    GameObject newBall = BallPoolSO.GetObject();
    Debug.Log(newBall.name);
  }
}