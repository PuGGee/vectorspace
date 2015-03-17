using UnityEngine;
using System.Collections;

public class MissionTab : Tab {
  
  public MissionTab(StationMenu s) : base(s) {}
  
  public override void render() {
    if (GUILayout.Button("Mission 1")) {
      GlobalObjects.mission_control.start_new_mission();
    }
    if (GUILayout.Button("Mission 2")) {
      GlobalObjects.mission_control.start_new_mission();
    }
    if (GUILayout.Button("Mission 3")) {
      GlobalObjects.mission_control.start_new_mission();
    }
  }
}
