using UnityEngine;
using System.Collections;

public class MissionControl : MonoBehaviour {
  
  private Mission mission;
  
  private bool _mission_marker_enabled;
  
  public Mission current_mission {
    get {
      return mission;
    }
  }
  
  public bool mission_marker_enabled {
    get {
      return _mission_marker_enabled;
    }
  }
  
  void Update() {
    if (mission != null) {
      print(mission.location);
      _mission_marker_enabled = !mission.started;
      if (mission.started && mission.test_win_conditions()) {
        PlayerData.credits += mission.credits;
        mission = null;
      } else {
        mission.test_proximity();
      }
    }
  }
  
  public void start_new_mission(int level) {
    _mission_marker_enabled = true;
    if (mission == null) {
      mission = new SearchAndDestroy(generate_mission_position(200, GlobalObjects.player.position), level);
    }
  }
  
  private Vector2 generate_mission_position(float distance, Vector2 center) {
    float angle = Random.value * Mathf.PI * 2;
    float x_component = Mathf.Cos(angle) * distance;
    float y_component = Mathf.Sin(angle) * distance;
    
    return center + new Vector2(x_component, y_component);
  }
}
