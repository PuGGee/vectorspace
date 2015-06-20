using UnityEngine;
using System.Collections;

public class MissileControl : ScannerControl {
  
  private MovementScript move_script {
    get {
      return GetComponent<MovementScript>();
    }
  }
  
  private MissileScript missile {
    get {
      return GetComponent<MissileScript>();
    }
  }
  
  protected override float weapon_speed {
    get {
      return move_script.max_speed;
    }
  }
  
  void FixedUpdate() {
    base.FixedUpdate();
    if (current_target_transform != null) {
      turn_towards(current_target_transform);
      Vector2 displacement = current_target_location - ((Vector2)position);
      move_script.align_vector(displacement);
    } else {
      move_script.forward();
    }
  }
  
  protected Transform find_target() {
    var object_list = GameObject.FindGameObjectsWithTag(ShipControl.ship_tag);
    var min_distance = Mathf.Infinity;
    GameObject closest = null;
    foreach (GameObject game_object in object_list) {
      if (missile.not_friend(game_object.transform)) {
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
  
  override protected Transform closest_enemy_ship() {
    return find_target();
  }
}
