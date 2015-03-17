using UnityEngine;
using System.Collections;

public class StationMenu : MonoBehaviour {
  
  public GUISkin skin;
  
  private StationScript station;
  
  private Tab current_tab;
  
  private MissionTab mission_tab;
  private SlotTab slot_tab;
  private StoreTab store_tab;
  
  public StationScript current_station {
    set {
      station = value;
    }
  }
  
  void Start() {
    mission_tab = new MissionTab(this);
    slot_tab = new SlotTab(this);
    store_tab = new StoreTab(this);
    current_tab = mission_tab;
  }
  
  void OnGUI() {
    GUI.skin = skin;
    
    GUILayout.BeginArea(new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.8f, Screen.height * 0.8f));
      GUILayout.BeginHorizontal();
        if (GUILayout.Button("Missions")) {
          goto_missions();
        }
        if (GUILayout.Button("Store")) {
          goto_store();
        }
        if (GUILayout.Button("Ship")) {
          goto_slots();
        }
      GUILayout.EndHorizontal();
      current_tab.render();
      if (GUILayout.Button("Leave")) {
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
}
