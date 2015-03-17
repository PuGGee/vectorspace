using UnityEngine;
using System.Collections;

public class ScannerControl : ShipControl {
  
  private const float shoot_threshold = 0.5f;
  private const int target_age_limit = 20;
  private const float angle_randomization = 0.5f;
  
  public int sensor_arc_width_degrees;
  private int current_target_counter;
  private int current_target_age_limit;
  protected Transform current_target_transform;
  protected float current_target_angle;
  protected Vector2 current_target_location;
  
  protected ArrayList targets;
  
  protected virtual float sensor_arc_start_degrees {
    get {
      return move_script.rotation - sensor_arc_width_degrees / 2;
    }
  }
  
  protected virtual float sensor_arc_end_degrees {
    get {
      return move_script.rotation + sensor_arc_width_degrees / 2;
    }
  }
  
  protected float sensor_arc_start_rads {
    get {
      return sensor_arc_start_degrees * Mathf.Deg2Rad;
    }
  }
  
  protected float sensor_arc_end_rads {
    get {
      return sensor_arc_end_degrees * Mathf.Deg2Rad;
    }
  }
  
  protected bool in_range(Vector2 target_position) {
    return Mathf.Abs(angle_towards(target_position)) <= shoot_threshold;
  }
  
  protected bool in_range(Transform target) {
    return in_range(target.position);
  }
  
  void Start() {
    targets = new ArrayList();
    if (sensor_arc_width_degrees == 0) sensor_arc_width_degrees = 100;
  }
  
  protected virtual void FixedUpdate() {
    scan();
    cull_sensor_targets();
    if (current_target_counter > current_target_age_limit) {
      current_target_counter = 0;
      current_target_age_limit = Random.Range(10, 30);
      choose_target();
    }
    current_target_counter++;
  }
  
  protected void choose_target() {
    float sqr_distance = Mathf.Infinity;
    SensorTarget closest_target = null;
    foreach (SensorTarget target in targets) {
      Vector2 displacement = target.location - position;
      float sqr_mag = displacement.sqrMagnitude;
      if (sqr_mag < sqr_distance) {
        sqr_distance = sqr_mag;
        closest_target = target;
      }
    }
    if (closest_target != null) {
      current_target_transform = closest_target.transform;
      current_target_angle = closest_target.angle + Random.Range(-angle_randomization, angle_randomization);
      current_target_location = closest_target.location;
    } else {
      current_target_transform = null;
    }
  }
  
  protected ArrayList enemy_ships() {
    var result = new ArrayList();
    var object_list = GameObject.FindGameObjectsWithTag(ShipControl.ship_tag);
    foreach (GameObject ship in object_list) {
      var enemy_script = ship.GetComponent<ShipScript>();
      if (team.enemy_of(enemy_script.team)) {
        result.Add(ship);
      }
    }
    return result;
  }
  
  protected Transform closest_enemy_ship() {
    return find_closest_ship_from_collection(enemy_ships());
  }
  
  protected float random_scan_angle_rads() {
    return Random.Range(sensor_arc_start_rads, sensor_arc_end_rads);
  }
  
  protected void scan() {
    var angle = random_scan_angle_rads();
    RaycastHit2D[] hits = Physics2D.RaycastAll(position, TrigHelper.direction_from_angle(angle));
    if (hits.Length > 0) {
      var hit = hits[0];
      if (hit.transform.gameObject == gameObject && hits.Length > 1) hit = hits[1];
      if (enemy_ships().Contains(hit.transform.gameObject)) {
        register_target(hit.transform, hit.point, angle);
      }
    }
  }
  
  protected virtual void cull_sensor_targets() {
    var targets_copy = new ArrayList(targets);
    foreach (SensorTarget target in targets_copy) {
      target.age++;
      if (target.age >= target_age_limit) targets.Remove(target);
    }
  }
  
  protected void register_target(Transform target_transform, Vector2 hit_location, float angle_rads) {
    foreach (SensorTarget target in targets) {
      if (target.transform == target_transform) {
        target.update_target(angle_rads, hit_location);
        return;
      }
    }
    targets.Add(new SensorTarget(target_transform, hit_location, angle_rads));
  }
}
