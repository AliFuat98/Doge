using UnityEngine;

public class ChainMovement : MonoBehaviour {
  [SerializeField] float speed;
  [SerializeField] float timeForDestroy;
  [SerializeField] GameObject ArrowHeadGO;

  SpriteRenderer spriteRenderer;
  BoxCollider2D boxCollider2D;
  int destroyedBallCount = 0;

  private void Start() {
    spriteRenderer = GetComponent<SpriteRenderer>();
    boxCollider2D = GetComponent<BoxCollider2D>();

    Destroy(gameObject, timeForDestroy);
  }

  private void Update() {
    // Change the height of the sprite
    float newHeight = spriteRenderer.size.y + speed * Time.deltaTime;
    spriteRenderer.size = new Vector2(spriteRenderer.size.x, newHeight);

    // Update the box collider size and offset
    boxCollider2D.size = new Vector2(boxCollider2D.size.x, newHeight);
    boxCollider2D.offset = new Vector2(boxCollider2D.offset.x, newHeight / 2);

    // change arrow head position
    Vector3 arrowHeadLocalPosition = ArrowHeadGO.transform.localPosition;
    arrowHeadLocalPosition.y = newHeight;
    ArrowHeadGO.transform.localPosition = arrowHeadLocalPosition;
  }

  void OnCollisionEnter2D(Collision2D collision) {
    if (collision.gameObject.TryGetComponent(out CeilMarker _)) {
      Destroy(gameObject);
    }

    if (collision.gameObject.TryGetComponent(out BallSplit ballSplit) && destroyedBallCount == 0) {
      ballSplit.Split();
      destroyedBallCount = 1;
      Destroy(gameObject);
    }
  }
}