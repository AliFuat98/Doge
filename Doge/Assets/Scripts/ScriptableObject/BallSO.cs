using UnityEngine;

[CreateAssetMenu()]
public class BallSO : ScriptableObject {
  public float scale;
  public Color color;
  public float mass;
  public BallSO NextSO;
}