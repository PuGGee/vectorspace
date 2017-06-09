using UnityEngine;
using System.Collections;

public class StationMenu : MonoBehaviour {

  public GUISkin skin;

  private Tab current_tab;

  private Rect screen_rect;

  private MissionTab mission_tab;
  private SlotTab slot_tab;
  private StoreTab store_tab;
  private ShipsTab ships_tab;

  public StationScript current_station { get; set; }

  void Start() {
    screen_rect = new Rect(UIHelper.gridx(1), UIHelper.gridy(1), UIHelper.gridx(10), UIHelper.gridy(10));
    mission_tab = new MissionTab(this, screen_rect);
    slot_tab = new SlotTab(this, screen_rect);
    store_tab = new StoreTab(this, screen_rect);
    ships_tab = new ShipsTab(this, screen_rect);
    current_tab = mission_tab;
  }

  void OnGUI() {
    GUI.skin = skin;

    GUILayout.BeginArea(screen_rect);
      GUILayout.BeginHorizontal();
        if (UIHelper.button("Missions", 1)) {
          goto_missions();
        }
        if (UIHelper.button("Store", 1)) {
          goto_store();
        }
        if (UIHelper.button("Hanger", 1)) {
          goto_slots();
        }
        if (UIHelper.button("Ships", 1)) {
          goto_ships();
        }
      GUILayout.EndHorizontal();
      current_tab.render();
      if (UIHelper.button("Leave", 1)) {
        GlobalObjects.game_control.undock();
      }
    GUILayout.EndArea();
  }

  public void goto_missions() {
    current_tab = mission_tab;
  }

  public void goto_store() {
    current_tab = store_tab;
  }

  public void goto_slots() {
    current_tab = slot_tab;
  }

  public void goto_ships() {
    current_tab = ships_tab;
  }
}
