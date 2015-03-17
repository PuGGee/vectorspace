using UnityEngine;
using System.Collections;

public class TurretControl : ScannerControl {
  
  private WeaponScript weapon_script;
  
  public WeaponScript weapon {
    get {
      return weapon_script;
    }
    set {
      weapon_script = value;
    }
  }
  
  public TurretHardpoint hardpoint {
    get {
      return weapon_script.hardpoint_script as TurretHardpoint;
    }
  }
  
  public override Vector2 position {
    get {
      return hardpoint.transform.position;
    }
  }
  
  public override ShipScript ship_script {
    get {
      return weapon_script.ship;
    }
  }
  
  public override MovementScript move_script {
    get {
      return transform.parent.GetComponent<MovementScript>();
    }
  }
  
  protected void Update() {
    var target = closest_enemy_in_arc();
    if (target) {
      weapon_script.direction_rads = -angle_towards_rads(target) + Mathf.PI / 2;
      weapon_script.turret_pull_trigger();
    }
  }
  
  protected bool angle_in_arc(float angle_rads) {
    if (hardpoint.arc_end_rads > hardpoint.arc_start_rads) {
      return angle_rads >= hardpoint.arc_start_rads && angle_rads <= hardpoint.arc_end_rads;
    } else {
      return angle_rads >= hardpoint.arc_start_rads || angle_rads <= hardpoint.arc_end_rads;
    }
  }
  
  protected Transform closest_enemy_in_arc() {
    var enemies = enemy_ships();
    var enemies_copy = new ArrayList(enemies);
    foreach (GameObject ship in enemies_copy) {
      var angle_rads = TrigHelper.normalize_angle_rads(angle_towards_rads(ship.transform) + TrigHelper.normalize_angle_rads(move_script.rotation_rads - Mathf.PI / 2));
      if (!angle_in_arc(angle_rads)) {
        enemies.Remove(ship);
      }
    }
    return find_closest_ship_from_collection(enemies);
  }
}
