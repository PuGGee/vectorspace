using UnityEngine;
using System.Collections;

public class MissionControl : MonoBehaviour {
  
  private Mission mission;
  
  public Mission current_mission {
    get {
      return mission;
    }
  }
  
  void Update() {
    if (mission != null) {
      if (mission.test_win_conditions()) {
        PlayerData.credits += mission.credits;
        mission = null;
      }
    }
  }
  
  public void start_new_mission() {
    if (mission == null) {
      mission = new SearchAndDestroy(generate_mission_position(100, GlobalObjects.player.transform.position), 1);
      mission.initialize();
    }
  }
  
  private Vector2 generate_mission_position(float distance, Vector2 center) {
    float angle = Random.value * Mathf.PI * 2;
    float x_component = Mathf.Cos(angle) * distance;
    float y_component = Mathf.Sin(angle) * distance;
    
    return center + new Vector2(x_component, y_component);
  }
}
