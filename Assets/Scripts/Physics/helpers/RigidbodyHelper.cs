using UnityEngine;
using System.Collections;

public class RigidbodyHelper {

  public static Rigidbody2D rigidbody_for(Transform transform) {
    if (transform.GetComponent<Rigidbody2D>() != null) {
      return transform.GetComponent<Rigidbody2D>();
    } else {
      return transform.parent.GetComponent<Rigidbody2D>();
    }
  }
  
  public static Vector2 get_velocity(Component component) {
    return component.GetComponent<MovementScript>().velocity;
  }
  
  public static void set_velocity(Rigidbody2D body, float speed, float angle_rads) {
    body.velocity = TrigHelper.direction_from_angle(angle_rads) * speed;
  }
  
  public static void add_velocity(Rigidbody2D body, float speed, float angle_rads) {
    body.velocity += TrigHelper.direction_from_angle(angle_rads) * speed;
  }
}
