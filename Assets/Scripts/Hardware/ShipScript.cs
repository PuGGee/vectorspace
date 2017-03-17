using UnityEngine;
using System.Collections;

public class ShipScript : MovementScript {

  public ShipScale scale;
  public int cost;

  private Team.Faction team_data;
  private WeaponSystem weapon_system;

  public Team.Faction team {
    get {
      return team_data;
    }
    set {
      team_data = value;
    }
  }

  public float structure_fraction {
    get {
      return GetComponent<DamageScript>().structure_fraction;
    }
  }

  public float armour_fraction {
    get {
      return GetComponent<DamageScript>().armour_fraction;
    }
  }

  public WeaponScript[] weapons {
    get {
      return GetComponentsInChildren<WeaponScript>();
    }
  }

  public void finalize() {
    weapon_system = new WeaponSystem(weapons);
  }

  public float shield_fraction {
    get {
      if (transform.Find("Shield")) {
        return transform.Find("Shield").GetComponent<ShieldScript>().shield_fraction;
      } else {
        return 0;
      }
    }
  }

  public float weapon_speed {
    get {
      return weapon_system.weapon_speed;
    }
  }

  public void pull_trigger() {
    weapon_system.pull_trigger();
  }

  void Update() {
    weapon_system.update();
  }

  public enum ShipScale {
    frigate = 1,
    destroyer = 2,
    dreadnought = 3
  }
}
