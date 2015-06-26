using UnityEngine;
using System.Collections;

public class ShipHelper {

  public static HardpointScript[] hardpoints(Transform ship_transform) {
    return ship_transform.GetComponentsInChildren<HardpointScript>(true) as HardpointScript[];
  }
  
  public static Transform find_closest_ship_from_collection(Transform centre, ArrayList collection) {
    var min_distance = Mathf.Infinity;
    GameObject closest = null;
    foreach (GameObject game_object in collection) {
      var game_object_script = game_object.GetComponent<ShipScript>();
      if (game_object.transform != centre) {
        Vector2 diff = game_object.transform.localPosition - centre.localPosition;
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
}
