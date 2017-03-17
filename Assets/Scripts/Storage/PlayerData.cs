using UnityEngine;
using System.Collections;

public class PlayerData {

  private static int credits_data;
  private static Transform ship_data;
  private static Transform[] equipment_data;
  private static ArrayList inventory_data;

  public static int credits {
    get {
      return credits_data;
    }
    set {
      credits_data = value;
    }
  }

  public static Transform ship {
    get {
      return ship_data;
    }
    set {
      ship_data = value;
      empty_equipment();
      equipment_data = new Transform[ShipHelper.hardpoints(ship_data).Length];
    }
  }

  public static ArrayList inventory {
    get {
      if (inventory_data == null) {
        inventory_data = new ArrayList();
      }
      return inventory_data;
    }
  }

  public static Blueprint blueprint {
    get {
      Blueprint player_blueprint = new Blueprint();
      player_blueprint.ship_prefab = ship_data;

      for (int i = 0; i < equipment_data.Length; i++) {
        player_blueprint.add_equipment(i, equipment_data[i]);
      }

      return player_blueprint;
    }
  }

  public static void add_inventory(Transform item) {
    inventory.Add(item);
  }

  public static void remove_inventory(Transform item) {
    inventory.Remove(item);
  }

  public static void add_equipment(int index, Transform item) {
    empty_hardpoint(index);
    equipment_data[index] = item;
    inventory.Remove(item);
  }

  public static Transform equipment_at(int index) {
    return equipment_data[index];
  }

  public static void empty_hardpoint(int index) {
    if (equipment_at(index) != null) {
      inventory.Add(equipment_at(index));
      equipment_data[index] = null;
    }
  }

  private static void empty_equipment() {
    if (equipment_data == null) return;
    for (int i = 0; i < equipment_data.Length; i++) {
      empty_hardpoint(i);
    }
  }
}
