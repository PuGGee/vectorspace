using UnityEngine;
using System.Collections;

public class Factory {
  
  protected static Transform make_object(Transform prefab, Transform parent, Vector2 position, Vector2? velocity = null) {
    Transform object_transform = GameObject.Instantiate(prefab) as Transform;
    object_transform.parent = parent;
    object_transform.localPosition = position;
    Vector3 pos = object_transform.localPosition;
    pos.z = 0;
    if (velocity.HasValue) {
      object_transform.rigidbody2D.velocity = velocity.Value;
    }
    return object_transform;
  }
}
