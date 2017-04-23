using UnityEngine;
using System.Collections;

public class CargoFactory : Factory {

  public static void make_credits(Vector2 position, int credits) {
    create_cargo_transform(position, null, credits);
  }

  public static void make_equipment(Vector2 position, Transform equipment) {
    create_cargo_transform(position, equipment, 0);
  }

  private static void create_cargo_transform(Vector2 position, Transform equipment, int credits) {
    var cargo_transform = make_object(GlobalPrefabs.find.cargo_crate, GlobalObjects.foreground, position);
    var cargo_script = cargo_transform.GetComponent<CargoScript>();
    cargo_script.loot_item = equipment;
    cargo_script.loot_credits = credits;
  }
}
