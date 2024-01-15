using UnityEngine;

public class BallMovement : MonoBehaviour {
  [SerializeField] float horizontalSpeed = 2.0f;
  [SerializeField] float bounceForce = 5f;
  Rigidbody2D rb;

  void Start() {
    rb = GetComponent<Rigidbody2D>();
  }

  void FixedUpdate() {
    // Set the constant horizontal velocity
    rb.velocity = new Vector2(horizontalSpeed, rb.velocity.y);
  }

  void OnCollisionEnter2D(Collision2D collision) {
    if (collision.gameObject.TryGetComponent(out GroundMarker _)) {
      rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
    }
  }

  public void ChangeHorizontalSpeed(bool change) {
    horizontalSpeed = change ? -horizontalSpeed : horizontalSpeed;
  }
}