using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChain : MonoBehaviour {
  [SerializeField] Transform chainPrefab;
  [SerializeField] Transform spawnPoint;

  Transform lastChain;

  private void Start() {
    GameInput.Instance.OnChainAction += GameInput_OnChainAction;
  }

  private void GameInput_OnChainAction(object sender, System.EventArgs e) {
    if (lastChain != null) {
      return;
    }
    lastChain = Instantiate(chainPrefab, spawnPoint.position, Quaternion.identity);
  }
}