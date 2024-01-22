using UnityEngine;

public class BallSplit : MonoBehaviour {
  [SerializeField] PoolManagerSO ballPoolSO;
  [SerializeField] BallSO currentBallSO;
  [SerializeField] float splitForce = 5f;

  private void Awake() {
    transform.localScale = currentBallSO.scale;
    GetComponent<SpriteRenderer>().color = currentBallSO.color;
    GetComponent<SpriteRenderer>().sortingOrder = currentBallSO.sortOrder;
    GetComponent<Rigidbody2D>().mass = currentBallSO.mass;
    GetComponent<BallMovement>().GoLeft();
  }

  public void Split() {
    if (currentBallSO.NextSO == null) {
      ballPoolSO.ReturnObject(gameObject);
      return;
    }

    GameObject leftBall = ballPoolSO.GetObject();
    GameObject rightdBall = ballPoolSO.GetObject();

    leftBall.transform.localScale = currentBallSO.NextSO.scale;
    leftBall.transform.position = transform.position;
    leftBall.GetComponent<SpriteRenderer>().color = currentBallSO.NextSO.color;
    leftBall.GetComponent<SpriteRenderer>().sortingOrder = currentBallSO.NextSO.sortOrder;
    leftBall.GetComponent<Rigidbody2D>().mass = currentBallSO.NextSO.mass;
    leftBall.GetComponent<Rigidbody2D>().AddForce(Vector2.up * splitForce, ForceMode2D.Impulse);
    leftBall.GetComponent<BallMovement>().GoLeft();
    leftBall.GetComponent<BallSplit>().SetCurrentBallSO(currentBallSO.NextSO);

    rightdBall.transform.localScale = currentBallSO.NextSO.scale;
    rightdBall.transform.position = transform.position;
    rightdBall.GetComponent<SpriteRenderer>().color = currentBallSO.NextSO.color;
    rightdBall.GetComponent<SpriteRenderer>().sortingOrder = currentBallSO.NextSO.sortOrder;
    rightdBall.GetComponent<Rigidbody2D>().mass = currentBallSO.NextSO.mass;
    rightdBall.GetComponent<Rigidbody2D>().AddForce(Vector2.up * splitForce, ForceMode2D.Impulse);
    rightdBall.GetComponent<BallMovement>().GoRight();
    rightdBall.GetComponent<BallSplit>().SetCurrentBallSO(currentBallSO.NextSO);

    ballPoolSO.ReturnObject(gameObject);
  }

  public void SetCurrentBallSO(BallSO ballSO) {
    currentBallSO = ballSO;
  }
}