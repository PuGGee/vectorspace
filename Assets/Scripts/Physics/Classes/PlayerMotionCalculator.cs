using UnityEngine;

public class PlayerMotionCalculator {

  private ShipScript ship;
  private Vector2 direction;

  public PlayerMotionCalculator(ShipScript ship, Vector2 direction) {
    this.ship = ship;
    this.direction = direction;
  }

  public void apply_motion() {
    var result = calculate_motion();
    apply_calculated_motion(result.x, result.y);
  }

  private Vector2 calculate_motion() {
    var distance = Vector2.Distance(Vector2.zero, direction);
    if (distance < 1) { return Vector2.zero; }
    var multiplyer = Mathf.Min(distance / 100, 1.0f);

    float divisor;
    if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)) {
      divisor = Mathf.Abs(direction.x);
    } else {
      divisor = Mathf.Abs(direction.y);
    }

    var xmagnitude = direction.x / divisor;
    var ymagnitude = direction.y / divisor;
    return new Vector2(xmagnitude, ymagnitude);
  }

  private void apply_calculated_motion(float x_motion, float y_motion) {
    if (x_motion > 0) {
      ship.turn_right(x_motion);
    } else {
      ship.turn_left(x_motion);
    }
    if (y_motion > 0) {
      ship.forward(y_motion);
    } else {
      ship.backward(-y_motion);
    }
  }
}
