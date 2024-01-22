using UnityEngine;

public class BallMovement : MonoBehaviour {
  [SerializeField] float horizontalSpeed = 2.0f;
  [SerializeField] float bounceForce = 5f;
  Rigidbody2D rb;
  int direction = 1;

  void Start() {
    rb = GetComponent<Rigidbody2D>();
  }

  void FixedUpdate() {
    // Set the constant horizontal velocity
    rb.velocity = new Vector2(horizontalSpeed * direction, rb.velocity.y);
  }

  public void GoLeft() {
    direction = 1;
  }

  public void GoRight() {
    direction = -1;
  }

  public void ToggleDirection() {
    direction *= -1;
  }

  void OnCollisionEnter2D(Collision2D collision) {
    if (collision.gameObject.TryGetComponent(out GroundMarker _)) {
      rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
    }

    if (collision.gameObject.TryGetComponent(out WallMarker _)) {
      ToggleDirection();
    }

    if (collision.gameObject.TryGetComponent(out CeilMarker _)) {
      gameObject.SetActive(false);
    }
  }
}