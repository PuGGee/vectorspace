using UnityEngine;
using System.Collections;

public class GameHUD : MonoBehaviour {
  
  public GUISkin skin;
  
  void OnGUI() {
    GUI.skin = skin;
    
    GUILayout.Box("Health", "health bar", GUILayout.Width(GlobalObjects.player.ship_script.structure_fraction * 150));
    GUILayout.Box("Armour", "armour bar", GUILayout.Width(GlobalObjects.player.ship_script.armour_fraction * 150));
    GUILayout.Box("Shields", "shield bar", GUILayout.Width(GlobalObjects.player.ship_script.shield_fraction * 150));
    GUILayout.Label("Credits: " + PlayerData.credits);
  }
}
