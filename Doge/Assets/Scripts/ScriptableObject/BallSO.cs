using UnityEngine;

[CreateAssetMenu()]
public class BallSO : ScriptableObject {
  public Vector3 scale;
  public Color color;
  public float mass;
  public int sortOrder;
  public BallSO NextSO;
}