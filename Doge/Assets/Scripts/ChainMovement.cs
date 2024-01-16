using UnityEngine;

public class ChainMovement : MonoBehaviour {
  [SerializeField] float speed;
  [SerializeField] GameObject ArrowHeadGO;

  SpriteRenderer spriteRenderer;
  BoxCollider2D boxCollider2D;

  private void Start() {
    spriteRenderer = GetComponent<SpriteRenderer>();
    boxCollider2D = GetComponent<BoxCollider2D>();
  }

  private void Update() {
    // Change the height of the sprite
    float newHeight = spriteRenderer.size.y + speed * Time.deltaTime;
    spriteRenderer.size = new Vector2(spriteRenderer.size.x, newHeight);

    // Update the box collider size and offset
    boxCollider2D.size = new Vector2(boxCollider2D.size.x, newHeight);
    boxCollider2D.offset = new Vector2(boxCollider2D.offset.x, newHeight / 2);

    Vector3 arrowHeadLocalPosition = ArrowHeadGO.transform.localPosition;
    arrowHeadLocalPosition.y = newHeight;
    ArrowHeadGO.transform.localPosition = arrowHeadLocalPosition;
  }
}