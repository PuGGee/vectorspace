using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponSystem {

  private Dictionary<int, ArrayList> weapon_groups;
  private bool trigger;

  public float weapon_speed {
    get{
      foreach (var weapon_group in weapon_groups.Values) {
        return ((WeaponScript)weapon_group[0]).projectile_speed;
      }
      return 0f;
    }
  }

  public WeaponSystem(WeaponScript[] weapons) {
    weapon_groups = new Dictionary<int, ArrayList>();
    setup_weapon_groups(weapons);
  }

  public void update() {
    trigger_weapon_groups();
    trigger = false;
  }

  public void pull_trigger() {
    trigger = true;
  }

  private void setup_weapon_groups(WeaponScript[] weapons) {
    foreach (var weapon in weapons) {
      if (weapon.is_turret) continue;
      if (!weapon_groups.ContainsKey(weapon.fire_rate)) weapon_groups.Add(weapon.fire_rate, new ArrayList());
      weapon_groups[weapon.fire_rate].Add(weapon);
    }
  }

  private void trigger_weapon_groups() {
    foreach (var key_value_pair in weapon_groups) {
      key_value_pair.Value.Sort(new WeaponSorter());
      int counter = 0;
      foreach (WeaponScript weapon in key_value_pair.Value) {
        if (trigger) {
          weapon.pull_trigger();
        } else {
          weapon.release_trigger(offset(counter, key_value_pair.Value.Count, key_value_pair.Key));
        }
        counter++;
      }
    }
  }
  
  private int offset(int index, int total_weapons, int fire_rate) {
    return fire_rate * index / total_weapons;
  }

  private class WeaponSorter : IComparer {

    int IComparer.Compare(object x, object y) {
      WeaponScript weaponx = (WeaponScript)x;
      WeaponScript weapony = (WeaponScript)y;
      if (weaponx.timer == weapony.timer) {
        return 0;
      } else if (weaponx.timer > weapony.timer) {
        return -1;
      } else {
        return 1;
      }
    }
  }
}
