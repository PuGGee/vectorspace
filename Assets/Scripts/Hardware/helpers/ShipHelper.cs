using UnityEngine;
using System.Collections;

public class ShipHelper {

  public static HardpointScript[] hardpoints(Transform ship_transform) {
    return ship_transform.GetComponentsInChildren<HardpointScript>(true) as HardpointScript[];
  }
  
  public static Transform closest_ship_from_collection(Transform centre, ArrayList collection) {
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
  
  public static Transform closest_ship_from_collection_in_arc(Transform centre, ArrayList collection, float rotation_rads, float arc_start_rads, float arc_end_rads) {
    var collection_copy = new ArrayList(collection);
        Debug.Log("derp");
    foreach (GameObject ship in collection) {
      
      var angle_towards = TrigHelper.angle_towards_rads(centre.position, ship.transform);
      var normalized_rotation = TrigHelper.normalize_angle_rads(rotation_rads - Mathf.PI / 2);
      var angle_rads = TrigHelper.normalize_angle_rads(angle_towards + normalized_rotation);
      
      if (!TrigHelper.angle_in_arc(angle_rads, arc_start_rads, arc_end_rads)) {
        collection_copy.Remove(ship);
      }
    }
    return closest_ship_from_collection(centre, collection_copy);
  }
}
