using UnityEngine;
using System.Collections;

public class SlotTab : Tab {

  public SlotTab(StationMenu s, Rect r) : base(s, r) {}

  private Transform active_item;

  public override void render() {
    render_player_inventory();
    render_ship_slots();
  }

  private void render_player_inventory() {
    foreach (Transform item in PlayerData.inventory) {
      if (UIHelper.button(EquipmentHelper.name(item), 1)) {
        active_item = item;
      }
    }
  }

  private void render_ship_slots() {
    var mid_point = centre();
    HardpointScript[] hardpoints = ShipHelper.hardpoints(PlayerData.ship);
    for (int i = 0; i < hardpoints.Length; i++) {
      var hardpoint = hardpoints[i];
      var equipment = PlayerData.equipment_at(i);
      Vector2 position = hardpoint.position;

      var rect = new Rect(mid_point.x + position.x * gridx(6), gridy(5) + position.y * gridy(2), 2, 1);
      string label = equipment == null ? "empty" : EquipmentHelper.name(equipment);
      var b = UIHelper.button(label, rect);

      if (b) {
        if (active_item != null) {
          PlayerData.add_equipment(i, active_item);
          active_item = null;
        } else {
          PlayerData.empty_hardpoint(i);
        }
      }
    }
  }
}
