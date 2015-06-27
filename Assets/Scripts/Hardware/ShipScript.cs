using UnityEngine;
using System.Collections;

public class ShipScript : MovementScript {
  
  public int scale;
  
  private Team.Faction team_data;
  
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
      return weapons[0].projectile_speed;
    }
  }
  
  public void pull_trigger() {
    foreach (WeaponScript weapon in weapons) {
      weapon.pull_trigger();
    }
  }
}
