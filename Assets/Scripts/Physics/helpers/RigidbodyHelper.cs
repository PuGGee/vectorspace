using UnityEngine;
using System.Collections;

public class RigidbodyHelper {

  public static Rigidbody2D rigidbody_for(Transform transform) {
    if (transform.rigidbody2D != null) {
      return transform.rigidbody2D;
    } else {
      return transform.parent.rigidbody2D;
    }
  }
  
  public static void set_velocity(Rigidbody2D body, float speed, float angle_rads) {
    body.velocity = TrigHelper.direction_from_angle(angle_rads) * speed;
  }
  
  public static void add_velocity(Rigidbody2D body, float speed, float angle_rads) {
    body.velocity += TrigHelper.direction_from_angle(angle_rads) * speed;
  }
}
