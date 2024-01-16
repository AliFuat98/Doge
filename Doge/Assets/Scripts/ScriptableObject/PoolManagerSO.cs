using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PoolManagerSO : ScriptableObject {
  public int poolSize = 10;
  public GameObject prefab;
  Queue<GameObject> pool = new();
  Transform parent;

  public void InitializePool(Transform parent) {
    this.parent = parent;

    for (int i = 0; i < poolSize; i++) {
      GameObject obj = Instantiate(prefab, parent);
      obj.SetActive(false);
      pool.Enqueue(obj);
    }
  }

  public GameObject GetObject() {
    if (pool.Count == 0) {
      ExpandPool(1);
    }

    GameObject obj = pool.Dequeue();
    obj.SetActive(true);
    return obj;
  }

  public void ReturnObject(GameObject obj) {
    obj.SetActive(false);
    pool.Enqueue(obj);
  }

  private void ExpandPool(int count) {
    for (int i = 0; i < count; i++) {
      GameObject obj = Instantiate(prefab, parent);
      obj.SetActive(false);
      pool.Enqueue(obj);
    }
  }
}