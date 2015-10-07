using UnityEngine;
using System.Collections;

public class MissionControl : MonoBehaviour {
  
  private Mission mission;
  
  public Mission current_mission {
    get {
      return mission;
    }
  }
  
  public bool mission_marker_enabled {
    get {
      // TODO
      return true;
    }
  }
  
  void Update() {
    if (mission != null) {
      if (mission.started && mission.test_win_conditions()) {
        PlayerData.credits += mission.credits;
        mission = null;
      } else {
        mission.test_proximity();
      }
    }
  }
  
  public void start_new_mission() {
    if (mission == null) {
      mission = new SearchAndDestroy(generate_mission_position(200, GlobalObjects.player.position), 1);
    }
  }
  
  private Vector2 generate_mission_position(float distance, Vector2 center) {
    float angle = Random.value * Mathf.PI * 2;
    float x_component = Mathf.Cos(angle) * distance;
    float y_component = Mathf.Sin(angle) * distance;
    
    return center + new Vector2(x_component, y_component);
  }
}
