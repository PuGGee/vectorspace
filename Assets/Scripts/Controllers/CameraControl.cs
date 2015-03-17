using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

  public Vector3 displacement;
  public float distance;

  void Update() {
    var direction_vector = GlobalObjects.player.transform.rotation * Vector2.up * distance;
    transform.position = GlobalObjects.player.transform.position + displacement + direction_vector;
    transform.rotation = GlobalObjects.player.transform.rotation;
  }
}
