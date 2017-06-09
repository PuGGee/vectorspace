using UnityEngine;
using System.Collections;

public class ShipFactory : Factory {

  public static ShipControl make(Blueprint blueprint, System.Type controller_type, Team.Faction team, Vector2 position, float rotation) {
    Transform transform = blueprint.make();

    add_equipment_to_transform(transform, blueprint);

    transform.localPosition = position;
    transform.eulerAngles = new Vector3(0, 0, rotation);
    var ship_script = transform.GetComponent<ShipScript>();
    ship_script.team = team;
    ship_script.finalize();
    return transform.gameObject.AddComponent(controller_type) as ShipControl;
  }

  private static void add_equipment_to_transform(Transform instantiated_transform, Blueprint blueprint) {
    DamageScript damage_script = instantiated_transform.GetComponent<DamageScript>();
    ShieldScript shield_script = instantiated_transform.Find("Shield").GetComponent<ShieldScript>();
    MovementScript movement_script = instantiated_transform.GetComponent<MovementScript>();

    HardpointScript[] hardpoints = ShipHelper.hardpoints(instantiated_transform);
    for (int i = 0; i < blueprint.equipment.Length; i++) {
      if (blueprint.equipment[i] != null) {
        Transform item = blueprint.equipment[i] as Transform;
        HardpointScript hardpoint = hardpoints[i];
        Transform transform = GameObject.Instantiate(item) as Transform;
        transform.parent = instantiated_transform;

        WeaponScript weapon_script = transform.GetComponent<WeaponScript>();
        Utility utility_script = transform.GetComponent<Utility>();
        if (weapon_script != null) {
          weapon_script.hardpoint = hardpoint.transform;
          if (hardpoint is TurretHardpoint) weapon_script.set_turret();
        } else {
          damage_script.armour += utility_script.armour;
          shield_script.shield_strength += utility_script.shield;
          shield_script.recharge_rate += utility_script.shield_recharge;
          movement_script.acceleration += utility_script.acceleration;
          movement_script.max_speed += utility_script.max_speed;
          movement_script.turn_rate += utility_script.turn_rate;
          movement_script.max_turn_speed += utility_script.max_turn;
        }
      }
    }
    damage_script.reset();
    if (shield_script.shield_strength <= 0) {
      shield_script.remove();
    } else {
      shield_script.reset();
    }
  }

  public static void make_player(Vector2 position, float rotation) {
    GlobalObjects.player = make(PlayerData.blueprint, typeof(PlayerControl), Team.player, position, rotation) as PlayerControl;
  }
}
