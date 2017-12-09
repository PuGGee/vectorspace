using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

  public Vector3 displacement;

  private float distance;

  new private Camera camera {
    get {
      return GetComponent<Camera>();
    }
  }

  void Update() {
    var direction_vector = GlobalObjects.player.transform.rotation * Vector2.up * distance;
    transform.position = GlobalObjects.player.transform.position + displacement + direction_vector;
    transform.rotation = GlobalObjects.player.transform.rotation;
    set_scale(Scale.value);
  }

  private void set_scale(int scale) {
    camera.orthographicSize = scale * 5 + 5;
    distance = 4 + 3 * scale;
  }
}
