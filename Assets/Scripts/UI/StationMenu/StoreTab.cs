using UnityEngine;
using System.Collections;

public class StoreTab : Tab {

  private Vector2 store_scroll_position;

  public StoreTab(StationMenu s) : base(s) {}
  
  private StationScript station {
    get {
      return station_menu.current_station;
    }
  }

  public override void render() {
    store_scroll_position = GUILayout.BeginScrollView(store_scroll_position);
    render_store_items();
    GUILayout.Space(20);
    render_items_to_sell();
    GUILayout.EndScrollView();
  }

  private void render_store_items() {
    foreach (var stock in station.current_stock) {
      if (GUILayout.Button(stock.name)) {
        buy(stock);
      }
    }
  }

  private void render_items_to_sell() {
    foreach (Transform item in PlayerData.inventory) {
      if (GUILayout.Button(EquipmentHelper.name(item))) {
        sell(item);
      }
    }
  }

  private void buy(StationScript.Stock stock) {
    if (PlayerData.credits >= EquipmentHelper.cost(stock.stock_item)) {
      PlayerData.add_inventory(stock.stock_item);
      PlayerData.credits -= EquipmentHelper.cost(stock.stock_item);
      station.reduce_stock(stock.stock_item);
    }
  }

  private void sell(Transform item) {
    PlayerData.remove_inventory(item);
    PlayerData.credits += EquipmentHelper.cost(item) / 2;
    station.increase_stock(item);
  }
}
