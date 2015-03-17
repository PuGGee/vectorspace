using UnityEngine;
using System.Collections;

public class HardpointScript : MonoBehaviour {
  
  public bool is_weapon_point;
  
  public Vector2 position {
    get {
      return transform.localPosition;
    }
  }
}
