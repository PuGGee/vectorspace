using UnityEngine;
using System.Collections;

public class DockingScript : MonoBehaviour {
  
  private StationScript station {
    get {
      return GetComponent<StationScript>();
    }
  }
  
  void OnCollisionEnter2D(Collision2D collision) {
    if (collision.transform == GlobalObjects.player.transform) {
      dock();
    }
  }
  
  void dock() {
    GlobalObjects.game_control.dock(station);
  }
}
