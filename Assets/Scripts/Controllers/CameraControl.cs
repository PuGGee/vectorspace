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
    update_position();
    update_rotation();
    set_scale(Scale.value);
  }

  private void update_position() {
    var direction_vector = GlobalObjects.player.transform.rotation * Vector2.up * distance;
    var target_position = GlobalObjects.player.transform.position + displacement + direction_vector;
    var distance_from_target_position = target_position - transform.position;
    transform.position += distance_from_target_position / 10f;
  }

  private void update_rotation() {
    var rotational_displacement_euler = GlobalObjects.player.transform.rotation.eulerAngles - transform.rotation.eulerAngles;
    var rotation = transform.rotation;
    if (rotational_displacement_euler.z > 180) {
      rotational_displacement_euler.z -= 360;
    } else if (rotational_displacement_euler.z < -180) {
      rotational_displacement_euler.z += 360;
    }
    rotation.eulerAngles = rotation.eulerAngles + (rotational_displacement_euler / 10f);
    transform.rotation = rotation;
  }

  private void set_scale(int scale) {
    camera.orthographicSize = scale * 10 + 5;
    distance = 4 + 3 * scale;
  }
}
