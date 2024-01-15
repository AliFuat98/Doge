using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSplit : MonoBehaviour
{
  [SerializeField] BallSO currentBallSO;

  void Update() {
    if (Input.GetKeyDown(KeyCode.Space)) {
      Split();
    }
  }

  void Split() {
    //In
  }

  public BallSO GeCurrentBallSO() {
    return currentBallSO;
  }
}
