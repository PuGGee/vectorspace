using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {
  
  private StationScript docked_at;
  private Map map;
  
  private MissionControl mission_control {
    get {
      return GetComponent<MissionControl>();
    }
  }
  
  private Vector2 player_position {
    get {
      return GlobalObjects.player.transform.localPosition;
    }
  }
  
  void Start() {
    map = Map.draw();
  }
  
  void Update() {
    if (Input.GetKeyDown("r")) {
      GlobalObjects.ship_spawner.make_random_ship(Team.pirates);
    }
    if (Input.GetKeyDown("t")) {
      GlobalObjects.ship_spawner.make_random_ship(Team.team1);
    }
    if (Input.GetKeyDown("m")) {
      mission_control.start_new_mission();
    }
    set_asteroid_density();
    check_station_proximity();
  }
  
  private void set_asteroid_density() {
    GlobalObjects.asteroid_spawner.density = map.density_at(player_position);
  }
  
  private void check_station_proximity() {
    GlobalObjects.ship_spawner.spawn_station(map.station_at(player_position));
  }
  
  public void dock(StationScript station) {
    docked_at = station;
    GlobalObjects.station_menu.current_station = station;
    enable_station_menu();
    Game.pause();
  }
  
  public void undock() {
    GlobalObjects.player.destroy();
    ShipFactory.make_player(new Vector2(0, 0));
    disable_station_menu();
    Game.unpause();
  }
  
  public void enable_station_menu() {
    GlobalObjects.hud.enabled = false;
    GlobalObjects.station_menu.enabled = true;
  }
  
  public void disable_station_menu() {
    GlobalObjects.hud.enabled = true;
    GlobalObjects.station_menu.enabled = false;
  }
  
  public void clear_world() {
    GlobalObjects.asteroid_spawner.clear();
    GlobalObjects.ship_spawner.clear();
  }
}
