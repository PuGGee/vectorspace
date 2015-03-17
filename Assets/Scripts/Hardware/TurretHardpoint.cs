using UnityEngine;
using System.Collections;

public class TurretHardpoint : HardpointScript {
  
  public float arc_start_degrees;
  public float arc_end_degrees;
  
  public float arc_start_rads {
    get {
      return arc_start_degrees * Mathf.Deg2Rad;
    }
  }
  
  public float arc_end_rads {
    get {
      return arc_end_degrees * Mathf.Deg2Rad;
    }
  }
}
