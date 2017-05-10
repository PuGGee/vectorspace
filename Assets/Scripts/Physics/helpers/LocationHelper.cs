using UnityEngine;
using System.Collections;

public class LocationHelper {

  public static Vector2 world_location(Vector2 screen_location) {
    var camera = Camera.main.GetComponent<Camera>();
    return (Vector2)camera.ScreenToWorldPoint((Vector3)screen_location);
  }
}
