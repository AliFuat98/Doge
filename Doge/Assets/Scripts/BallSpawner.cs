using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {
  ObjectPool pool;

  private void Start() {
    pool = GetComponent<ObjectPool>();
  }

  public void SpawnBall() {
    var firstBall = pool.GetObject();
    var SecondBall = pool.GetObject();

    // use ball SO to change
    BallSO ballSO = firstBall.GetComponent<BallSplit>().GeCurrentBallSO();


    BallMovement ballMovement = firstBall.GetComponent<BallMovement>();
    ballMovement.ChangeHorizontalSpeed(change : true);

    ballMovement = SecondBall.GetComponent<BallMovement>();
    ballMovement.ChangeHorizontalSpeed(change: false);
  }
}