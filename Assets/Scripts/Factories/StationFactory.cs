using UnityEngine;
using System.Collections;

public class StationFactory : Factory {
  
  public static void make(Transform station_prefab, Vector2 position) {
    var transform = make_object(station_prefab, GlobalObjects.foreground, position);
  }
}
