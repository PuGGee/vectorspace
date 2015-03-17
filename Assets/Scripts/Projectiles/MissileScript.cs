using UnityEngine;
using System.Collections;

public class MissileScript : Explosive {
  
  private Vector2 direction;
  
  private Transform target;
  
  private MovementScript move_script {
    get {
      return GetComponent<MovementScript>();
    }
  }
  
  private ShipControl control_script {
    get {
      return GetComponent<ShipControl>();
    }
  }
  
  void Start () {
    Destroy(gameObject, 10);
  }
  
  void FixedUpdate() {
    move_script.forward();
    if (target != null) {
      control_script.turn_towards(target);
    }
  }
  
  public void set_acceleration_and_direction(float acceleration, float angle_rads) {
    move_script.acceleration = acceleration;
    transform.localEulerAngles = new Vector3(0, 0, angle_rads * Mathf.Rad2Deg);
    target = find_target();
  }
  
  void OnTriggerEnter2D (Collider2D collider) {
    if (not_friend(collider.transform) && !collider.isTrigger) {
      explode();
    }
  }
  
  protected Transform find_target() {
    var object_list = GameObject.FindGameObjectsWithTag(ShipControl.ship_tag);
    var min_distance = Mathf.Infinity;
    GameObject closest = null;
    foreach (GameObject game_object in object_list) {
      if (not_friend(game_object.transform)) {
        Vector2 diff = game_object.transform.localPosition - transform.localPosition;
        var distance = diff.sqrMagnitude;
        var angle = control_script.angle_towards(game_object.transform);
        var fitness = distance + angle * angle;
        if (fitness < min_distance) {
          min_distance = fitness;
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
}
