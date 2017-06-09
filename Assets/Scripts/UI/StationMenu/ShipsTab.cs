using UnityEngine;
using System.Collections;

public class ShipsTab : Tab {

  public ShipsTab(StationMenu s, Rect r) : base(s, r) {}

  public override void render() {
    if (UIHelper.button("Ship 1", 1)) {
      buy(GlobalPrefabs.find.ship1);
    }
    if (UIHelper.button("Ship 2", 1)) {
      buy(GlobalPrefabs.find.ship2);
    }
    if (UIHelper.button("Ship 3", 1)) {
      buy(GlobalPrefabs.find.ship3);
    }
  }

  private void buy(Transform ship) {
    if (PlayerData.credits >= ShipHelper.cost(ship)) {
      PlayerData.credits -= ShipHelper.cost(ship) - salvage_value();
      PlayerData.ship = ship;
    }
  }

  private int salvage_value() {
    return ShipHelper.cost(PlayerData.ship) / 2;
  }
}
