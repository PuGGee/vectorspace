using UnityEngine;
using System.Collections;

public class MissionTab : Tab {

  public MissionTab(StationMenu s, Rect r) : base(s, r) {}

  public override void render() {
    if (UIHelper.button("Easy Mission", 1)) {
      GlobalObjects.mission_control.start_new_mission(1);
    }
    if (UIHelper.button("Normal Mission", 1)) {
      GlobalObjects.mission_control.start_new_mission(2);
    }
    if (UIHelper.button("Hard Mission", 1)) {
      GlobalObjects.mission_control.start_new_mission(3);
    }
  }
}
