using UnityEngine;
using System.Collections;

public class AIControl : ScannerControl {

  private Waypoint waypoint;

  public void set_waypoint(Vector2 waypoint) {
    this.waypoint = new Waypoint(position, waypoint);
  }

  public void choose_random_waypoint() {
    Vector2 target;
    // while (true) {
      target = TrigHelper.random_location(position, 30);
      // RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction);

    // }
    waypoint = new Waypoint(position, target);
  }

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
    } else if (waypoint != null) {
      move_towards(waypoint.target);
      if (waypoint.reached(position)) {
        choose_random_waypoint();
      }
    }
  }

  protected void move_towards(Vector2 target_position) {
    turn_towards(target_position, current_randomization);
    ship_script.forward();
  }

  private class Waypoint {

    private const int reached_distance = 3;

    private Vector2 _origin;
    private Vector2 _target;

    public float angle {
      get {
        return Vector2.Angle(_origin, _target);
      }
    }

    public Vector2 target {
      get {
        return _target;
      }
    }

    public Waypoint(Vector2 origin, Vector2 target) {
      _origin = origin;
      _target = target;
    }

    public bool reached(Vector2 position) {
      return (target - position).magnitude < reached_distance;
    }
  }
}
