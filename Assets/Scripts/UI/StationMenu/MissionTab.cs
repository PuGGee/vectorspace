using UnityEngine;
using System.Collections;

public class MissionTab : Tab {
  
  public MissionTab(StationMenu s) : base(s) {}
  
  public override void render() {
    if (GUILayout.Button("Easy Mission")) {
      GlobalObjects.mission_control.start_new_mission(1);
    }
    if (GUILayout.Button("Normal Mission")) {
      GlobalObjects.mission_control.start_new_mission(2);
    }
    if (GUILayout.Button("Hard Mission")) {
      GlobalObjects.mission_control.start_new_mission(3);
    }
  }
}
