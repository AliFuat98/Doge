using UnityEngine;

public class PlayerMovement : MonoBehaviour {
  [SerializeField] float speed = 5.0f; // Speed of the player
  Rigidbody2D rb;
  GameInput input;
  float moveX;

  void Start() {
    rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    input = GameInput.Instance;
  }

  void Update() {
    moveX = input.GetMovementAxis();
  }

  void FixedUpdate() {
    rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
  }
}