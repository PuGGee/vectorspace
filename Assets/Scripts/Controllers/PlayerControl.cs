using UnityEngine;
using System.Collections;

public class PlayerControl : ShipControl {

  private Vector2 drag;
  private bool dragging;

	void Update () {
	  if (Input.GetKey("w")) {
      ship_script.forward();
    }
    if (Input.GetKey("s")) {
      ship_script.backward();
    }
    if (Input.GetKey("a")) {
      ship_script.turn_left();
    } else if (Input.GetKey("d")) {
      ship_script.turn_right();
    } else if(!dragging) {
      ship_script.no_turn();
    }
    if (Input.GetKey("space")) {
      ship_script.pull_trigger();
    }

    var mouse_position = (Vector2)Input.mousePosition;
    if (Input.GetMouseButtonDown(0)) {
      if (mouse_position.x < Screen.width / 2) {
        ship_script.pull_trigger();
      } else {
        drag = mouse_position;
        dragging = true;
      }
    }

    if (Input.GetMouseButtonUp(0)) {
      dragging = false;
    }

    if (dragging) {
      var point1 = LocationHelper.world_location(drag);
      var point2 = LocationHelper.world_location(mouse_position);
      SfxFactory.make_line(point1, point2);
      calculate_motion(mouse_position - drag);
    }

    // if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
    // }
	}

  private void calculate_motion(Vector2 direction) {
    var distance = Vector2.Distance(Vector2.zero, direction);
    if (distance < 1) { return; }
    var multiplyer = Mathf.Min(distance / 100, 1.0f);

    float divisor;

    if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)) {
      divisor = Mathf.Abs(direction.x);
    } else {
      divisor = Mathf.Abs(direction.y);
    }

    var xmagnitude = direction.x / divisor;
    var ymagnitude = direction.y / divisor;
    if (xmagnitude > 0) {
      ship_script.turn_right(xmagnitude);
    } else {
      ship_script.turn_left(xmagnitude);
    }
    if (ymagnitude > 0) {
      ship_script.forward(ymagnitude);
    } else {
      ship_script.backward(ymagnitude);
    }
  }
}
