using UnityEngine;
using System.Collections;

public class ShipControl : MonoBehaviour {

  public const string ship_tag = "ship";
  private const float turn_threshold = 0.5f;

  public virtual MovementScript move_script {
    get {
      return gameObject.GetComponent<MovementScript>();
    }
  }
  
  public virtual ShipScript ship_script {
    get {
      return gameObject.GetComponent<ShipScript>();
    }
  }
  
  public Team.Faction team {
    get {
      return ship_script.team;
    }
    set {
      ship_script.team = value;
    }
  }
  
  public virtual Vector2 position {
    get {
      return transform.position;
    }
  }
  
  protected Transform find_closest_ship_from_collection(ArrayList collection) {
    var min_distance = Mathf.Infinity;
    GameObject closest = null;
    foreach (GameObject game_object in collection) {
      var game_object_script = game_object.GetComponent<ShipScript>();
      if (game_object_script != ship_script) {
        Vector2 diff = game_object.transform.localPosition - transform.localPosition;
        var distance = diff.sqrMagnitude;
        if (distance < min_distance) {
          min_distance = distance;
          closest = game_object;
        }
      }
    }
    if (closest == null) {
      return null;
    } else {
      return closest.transform;
    }
  }
  
  public virtual float angle_towards(Vector2 target_position) {
    Vector2 displacement = target_position - position;
    return Vector3.Cross(displacement, move_script.direction).z;
  }
  
  public virtual float angle_towards(Transform target) {
    return angle_towards(target.position);
  }
  
  public virtual float angle_towards_rads(Transform target) {
    Vector2 displacement = target.position - ((Vector3)position);
    return Mathf.Atan2(displacement.x, displacement.y);
  }
  
  public void turn_towards(Vector2 target_position) {
    var angle = angle_towards(target_position);
    if (Mathf.Abs(angle) < turn_threshold) {
      move_script.no_turn();
    } else if (angle < 0) {
      move_script.turn_left();
    } else {
      move_script.turn_right();
    }
  }
  
  public void turn_towards(Transform target) {
    turn_towards(target.position);
  }
  
  public void destroy() {
    Destroy(gameObject);
  }
}
