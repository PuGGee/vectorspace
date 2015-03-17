using UnityEngine;
using System.Collections;

public class PlayerControl : ShipControl {
	
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
    } else {
      ship_script.no_turn();
    }
    if (Input.GetKey("space")) {
      ship_script.pull_trigger();
    }
	}
}
