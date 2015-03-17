using UnityEngine;
using System.Collections;

public class EquipmentHelper {

  public static string name(Transform equipment_transform) {
    return equipment(equipment_transform).name;
  }
  
  public static int cost(Transform equipment_transform) {
    return equipment(equipment_transform).cost;
  }
  
  public static bool is_weapon(Transform equipment_transform) {
    return equipment_transform.GetComponent<WeaponScript>() != null;
  }
  
  private static Equipment equipment(Transform equipment_transform) {
    return equipment_transform.GetComponent<Equipment>();
  }
}
