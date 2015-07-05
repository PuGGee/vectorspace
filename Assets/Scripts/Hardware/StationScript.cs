using UnityEngine;
using System.Collections;

public class StationScript : MonoBehaviour {
  
  private Transform undocker {
    get {
      return transform.Find("undocker");
    }
  }
  
  public Vector2 undock_position {
    get {
      return undocker.position;
    }
  }
  
  public float undock_rotation {
    get {
      return undocker.eulerAngles.z;
    }
  }
}
