using UnityEngine;
using System.Collections;

public class TrigHelper {

  public static Vector2 direction_from_angle(float angle_rads) {
    float x_component = Mathf.Cos(angle_rads);
    float y_component = Mathf.Sin(angle_rads);
    return new Vector2(x_component, y_component);
  }
  
  public static float normalize_angle_rads(float angle) {
    float new_angle = angle;
    while (new_angle <= -Mathf.PI) new_angle += Mathf.PI * 2;
    while (new_angle > Mathf.PI) new_angle -= Mathf.PI * 2;
    return new_angle;
  }
  
  public static bool angle_in_arc(float angle_rads, float arc_start_rads, float arc_end_rads) {
    if (arc_end_rads > arc_start_rads) {
      return angle_rads >= arc_start_rads && angle_rads <= arc_end_rads;
    } else {
      return angle_rads >= arc_start_rads || angle_rads <= arc_end_rads;
    }
  }
  
  public static float angle_towards(Vector2 centre, Vector2 direction, Vector2 target_position) {
    Vector2 displacement = target_position - centre;
    return Vector3.Cross(displacement, direction).z;
  }
  
  public static float angle_towards(Vector2 centre, Vector2 direction, Transform target) {
    return angle_towards(centre, direction, target.position);
  }
  
  public static float angle_towards_rads(Vector2 centre, Vector2 target_position) {
    Vector2 displacement = target_position - centre;
    return Mathf.Atan2(displacement.x, displacement.y);
  }
  
  public static float angle_towards_rads(Vector2 centre, Transform target) {
    Debug.Log("centre.position " + centre);
    Debug.Log("ship.transform " + target.position);
    Debug.Log("angle_rads " + angle_towards_rads(centre, target.position));
    return angle_towards_rads(centre, target.position);
  }
}
