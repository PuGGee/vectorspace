using UnityEngine;
using System.Collections;

public class UIControl : MonoBehaviour {

  public Transform station_menu_group;

  private GameHUD hud {
    get {
      return GetComponent<GameHUD>();
    }
  }

  private StationMenu station_menu {
    get {
      return GetComponent<StationMenu>();
    }
  }

  private MapUI map {
    get {
      return GetComponent<MapUI>();
    }
  }

  public void open_station_menu(StationScript station) {
    hud.enabled = false;
    UIHelper.show_group(station_menu_group);

    // station_menu.enabled = true;
    // station_menu.current_station = station;
  }

  public void close_station_menu() {
    hud.enabled = true;
    UIHelper.hide_group(station_menu_group);

    // station_menu.enabled = false;
  }

  public void open_map() {
    map.enabled = true;
  }

  public void close_map() {
    map.enabled = false;
  }

  public void toggle_map() {
    map.enabled = !map.enabled;
  }

  public void show_game_over() {
    UIHelper.show_group(GameObject.Find("GameOverGroup").transform);
  }
}
