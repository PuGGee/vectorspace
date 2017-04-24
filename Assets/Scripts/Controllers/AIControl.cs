using UnityEngine;
using System.Collections;

public class AIControl : ScannerControl {

  protected override Transform body_transform {
    get {
      return transform;
    }
  }

  protected void Update () {
    if (current_target_transform != null) {
      move_towards(current_target_location);

      if (in_range(current_target_location)) {
        ship_script.pull_trigger();
      }
    } else {
      var target = closest_enemy_ship();
      if (target != null) move_towards(target.position);
    }
  }

  protected void move_towards(Vector2 target_position) {
    turn_towards(target_position, current_randomization);
    ship_script.forward();
  }
}
