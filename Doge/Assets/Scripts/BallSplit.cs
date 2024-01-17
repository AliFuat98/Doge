using UnityEngine;

public class BallSplit : MonoBehaviour {
  [SerializeField] PoolManagerSO ballPoolSO;
  [SerializeField] BallSO currentBallSO;
  [SerializeField] float splitForce = 5f;

  void Split() {
    if (currentBallSO.NextSO == null) {
      Debug.Log("destroyed the ball");
      ballPoolSO.ReturnObject(gameObject);
      return;
    }

    BallMovement leftBall = ballPoolSO.GetObject().GetComponent<BallMovement>();
    BallMovement rightdBall = ballPoolSO.GetObject().GetComponent<BallMovement>();

    leftBall.transform.localScale = currentBallSO.NextSO.scale;
    leftBall.transform.position = transform.position;
    leftBall.GetComponent<SpriteRenderer>().color = currentBallSO.NextSO.color;
    leftBall.GetComponent<Rigidbody2D>().mass = currentBallSO.NextSO.mass;
    leftBall.GetComponent<Rigidbody2D>().AddForce(Vector2.up * splitForce, ForceMode2D.Impulse);
    leftBall.GoLeft();

    rightdBall.transform.localScale = currentBallSO.NextSO.scale;
    rightdBall.transform.position = transform.position;
    rightdBall.GetComponent<SpriteRenderer>().color = currentBallSO.NextSO.color;
    rightdBall.GetComponent<Rigidbody2D>().mass = currentBallSO.NextSO.mass;
    rightdBall.GetComponent<Rigidbody2D>().AddForce(Vector2.up * splitForce, ForceMode2D.Impulse);
    rightdBall.GoRight();

    ballPoolSO.ReturnObject(gameObject);
  }
}