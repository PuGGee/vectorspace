using UnityEngine;
using System.Collections;

public class SlotTab : Tab {

  public SlotTab(StationMenu s) : base(s) {}

  private Transform active_item;

  public override void render() {
    render_player_inventory();
    render_ship_slots();
  }

  private void render_player_inventory() {
    foreach (Transform item in PlayerData.inventory) {
      if (GUILayout.Button(EquipmentHelper.name(item))) {
        active_item = item;
      }
    }
  }

  private void render_ship_slots() {
    var mid_point = UIHelper.centre;
    HardpointScript[] hardpoints = ShipHelper.hardpoints(PlayerData.ship);
    for (int i = 0; i < hardpoints.Length; i++) {
      var hardpoint = hardpoints[i];
      var equipment = PlayerData.equipment_at(i);
      Vector2 position = hardpoint.position;
      var b = GUI.Button(new Rect(mid_point.x + position.x * 100, mid_point.y + position.y * 100, 60, 60), equipment == null ? "empty" : EquipmentHelper.name(equipment));
      if (b) {
        if (active_item != null) {
          PlayerData.add_equipment(i, active_item);
        } else {
          PlayerData.empty_hardpoint(i);
        }
      }
    }
  }
}
