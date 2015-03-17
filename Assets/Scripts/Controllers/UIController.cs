using UnityEngine;
using System.Collections;

public class UIControl : MonoBehaviour {
  
  private GameHUD hud {
    get {
      return GetComponent<GameHUD>();
    }
  }
  
  private StationMenu station_menu {
    get {
      return GetComponent<StationMenu>();
    }
  }
  
  void dock() {
    
  }
}
