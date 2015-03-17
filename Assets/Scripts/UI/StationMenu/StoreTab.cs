using UnityEngine;
using System.Collections;

public class StoreTab : Tab {
  
  private Vector2 store_scroll_position;
  
  public StoreTab(StationMenu s) : base(s) {}
  
  public override void render() {
    store_scroll_position = GUILayout.BeginScrollView(store_scroll_position);
    if (GUILayout.Button("Weapon 1")) {
      buy(GlobalPrefabs.find.weapon1);
    }
    if (GUILayout.Button("Weapon 2")) {
      buy(GlobalPrefabs.find.weapon2);
    }
    if (GUILayout.Button("Weapon 3")) {
      buy(GlobalPrefabs.find.weapon3);
    }
    if (GUILayout.Button("Weapon 4")) {
      buy(GlobalPrefabs.find.weapon4);
    }
    if (GUILayout.Button("Weapon 5")) {
      buy(GlobalPrefabs.find.weapon5);
    }
    if (GUILayout.Button("Shield")) {
      buy(GlobalPrefabs.find.shield_gen1);
    }
    if (GUILayout.Button("Armour")) {
      buy(GlobalPrefabs.find.armour1);
    }
    if (GUILayout.Button("Engine")) {
      buy(GlobalPrefabs.find.engine1);
    }
    GUILayout.Space(20);
    foreach (Transform item in PlayerData.inventory) {
      if (GUILayout.Button(EquipmentHelper.name(item))) {
        sell(item);
      }
    }
    GUILayout.EndScrollView();
  }
  
  private void buy(Transform item) {
    if (PlayerData.credits >= EquipmentHelper.cost(item)) {
      PlayerData.add_inventory(item);
      PlayerData.credits -= EquipmentHelper.cost(item);
    }
  }
  
  private void sell(Transform item) {
    PlayerData.remove_inventory(item);
    PlayerData.credits += EquipmentHelper.cost(item) / 2;
  }
}
