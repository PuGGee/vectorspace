using UnityEngine;
using System.Collections;

public class PlayerData {

  public int _credits { get; set; }
  public Transform _ship { get; set; }
  public Transform[] _equipment { get; set; }
  public ArrayList _inventory { get; set; }

  private static PlayerData _instance;
  private static PlayerData instance {
    get {
      if (_instance == null) {
        _instance = new PlayerData();
      }
      return _instance;
    }
  }

  public static int credits {
    get {
      return instance._credits;
    }
    set {
      instance._credits = value;
    }
  }

  public static Transform ship {
    get {
      return instance._ship;
    }
    set {
      instance._ship = value;
      empty_equipment();
      instance._equipment = new Transform[ShipHelper.hardpoints(ship).Length];
    }
  }

  public static ArrayList inventory {
    get {
      if (instance._inventory == null) {
        instance._inventory = new ArrayList();
      }
      return instance._inventory;
    }
  }

  public static Blueprint blueprint {
    get {
      Blueprint player_blueprint = new Blueprint();
      player_blueprint.ship_prefab = ship;

      for (int i = 0; i < instance._equipment.Length; i++) {
        player_blueprint.add_equipment(i, instance._equipment[i]);
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
    instance._equipment[index] = item;
    inventory.Remove(item);
  }

  public static Transform equipment_at(int index) {
    return instance._equipment[index];
  }

  public static void empty_hardpoint(int index) {
    if (equipment_at(index) != null) {
      inventory.Add(equipment_at(index));
      instance._equipment[index] = null;
    }
  }

  private static void empty_equipment() {
    if (instance._equipment == null) return;
    for (int i = 0; i < instance._equipment.Length; i++) {
      empty_hardpoint(i);
    }
  }
}
