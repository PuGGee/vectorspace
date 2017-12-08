using UnityEngine;
using System.Collections;

public class MenuDramatisationControl : MonoBehaviour {

  const int SCALE = 1;
  const int ASTEROID_DENSITY = 50;

  public int scale {
    get {
      return SCALE;
    }
  }

  void Start() {
    GlobalObjects.asteroid_spawner.density = ASTEROID_DENSITY;
  }
}
