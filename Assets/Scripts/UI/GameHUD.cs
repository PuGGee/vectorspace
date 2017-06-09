using UnityEngine;
using System.Collections;

public class GameHUD : MonoBehaviour {

  public GUISkin skin;

  void OnGUI() {
    GUI.skin = skin;

    var bar_width = UIHelper.gridx(4);
    var bar_height = UIHelper.gridy(1);
    var screen_rect = new Rect(UIHelper.gridx(1), UIHelper.gridy(1), UIHelper.gridx(10), UIHelper.gridy(10));

    GUILayout.BeginArea(screen_rect);
      GUILayout.Box("Health", "health bar", GUILayout.Width(GlobalObjects.player.ship_script.structure_fraction * bar_width),
                                            GUILayout.Height(bar_height));
      GUILayout.Box("Armour", "armour bar", GUILayout.Width(GlobalObjects.player.ship_script.armour_fraction * bar_width),
                                            GUILayout.Height(bar_height));
      GUILayout.Box("Shields", "shield bar", GUILayout.Width(GlobalObjects.player.ship_script.shield_fraction * bar_width),
                                             GUILayout.Height(bar_height));
      GUILayout.Label("Credits: " + PlayerData.credits);
    GUILayout.EndArea();

  }
}
