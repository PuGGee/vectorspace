using UnityEngine;
using System.Collections;

public class ShipHelper {

  public static HardpointScript[] hardpoints(Transform ship_transform) {
    return ship_transform.GetComponentsInChildren<HardpointScript>(true) as HardpointScript[];
  }
}
