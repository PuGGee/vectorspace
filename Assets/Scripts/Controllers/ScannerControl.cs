using UnityEngine;
using System.Collections;

public class ScannerControl : ShipControl {
  
  private const float shoot_threshold = 0.5f;
  private const float angle_randomization = 0.1f;
  
  protected float current_randomization;
  private int current_target_age_limit;
  private int current_target_counter;
  private Vector2 target_offset;
  protected Transform current_target_transform;
  
  protected Vector2 current_target_location {
    get {
      return ((Vector2)current_target_transform.position) + target_offset;
    }
  }
  
  protected virtual float weapon_speed {
    get {
      return ship_script.weapon_speed;
    }
  }
  
  protected bool in_range(Vector2 target_position) {
    return Mathf.Abs(angle_towards(target_position)) <= shoot_threshold;
  }
  
  protected bool in_range(Transform target) {
    return in_range(target.position);
  }
  
  protected virtual void FixedUpdate() {
    if (current_target_counter > current_target_age_limit) {
      current_target_counter = 0;
      current_target_age_limit = Random.Range(10, 30);
      choose_target();
    }
    current_target_counter++;
  }
  
  protected void choose_target() {
    current_randomization = Random.Range(-angle_randomization, angle_randomization);
    
    current_target_transform = closest_enemy_ship();
    target_offset = predict_target_offset(current_target_transform);
  }
  
  protected Vector2 predict_target_offset(Transform target) {
    Vector2 displacement = ((Vector2)target.position) - position;
    float time = displacement.magnitude / weapon_speed;
    Vector2 relative_velocity = RigidbodyHelper.get_velocity(target) - RigidbodyHelper.get_velocity(this);
    return relative_velocity * time;
  }
  
  protected ArrayList enemy_ships() {
    var result = new ArrayList();
    var object_list = GameObject.FindGameObjectsWithTag(ShipControl.ship_tag);
    foreach (GameObject ship in object_list) {
      var enemy_script = ship.GetComponent<ShipScript>();
      if (enemy_script != null && team.enemy_of(enemy_script.team)) {
        result.Add(ship);
      }
    }
    return result;
  }
  
  protected virtual Transform closest_enemy_ship() {
    return find_closest_ship_from_collection(enemy_ships());
  }
}
