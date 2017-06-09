using UnityEngine;
using System.Collections;

public class PlayerControl : ShipControl {

  private Vector2 drag;
  private bool dragging;

	void Update () {
	  if (Game.paused) { return; }
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
      ship_script.no_turn(); // This is important :D
    }
    if (Input.GetKey("space")) {
      ship_script.pull_trigger();
    }

    // var mouse_position = (Vector2)Input.mousePosition;
    // if (Input.GetMouseButtonDown(0)) {
    //   if (mouse_position.x < Screen.width / 2) {
    //     ship_script.pull_trigger();
    //   } else {
    //     drag = mouse_position;
    //     dragging = true;
    //   }
    // }

    // if (Input.GetMouseButtonUp(0)) {
    //   dragging = false;
    // }

    // if (dragging) {
    //   var point1 = LocationHelper.world_location(drag);
    //   var point2 = LocationHelper.world_location(mouse_position);
    //   SfxFactory.make_line(point1, point2);
    //   new PlayerMotionCalculator(ship_script, mouse_position - drag).apply_motion();
    // }

    // Proper stuff
    dragging = false;

    for (int i = 0; i < Input.touchCount; i++) {
      var touch = Input.GetTouch(i);
      if (touch.position.x < Screen.width / 2) {
        ship_script.pull_trigger();
      } else {
        dragging = true;
        if (touch.phase == TouchPhase.Began) {
          drag = touch.position;
        } else {
          var point1 = LocationHelper.world_location(drag);
          var point2 = LocationHelper.world_location(touch.position);
          SfxFactory.make_line(point1, point2);
          new PlayerMotionCalculator(ship_script, touch.position - drag).apply_motion();
        }
      }
    }
	}
}
