using UnityEngine;
using System.Collections;

public class DockingScript : MonoBehaviour {
  
  private StationScript station {
    get {
      return transform.parent.GetComponent<StationScript>();
    }
  }
  
  void OnTriggerEnter2D(Collider2D collider) {
    if (collider.transform == GlobalObjects.player.transform) {
      dock();
    }
  }
  
  void dock() {
    GlobalObjects.game_control.dock(station);
  }
}
