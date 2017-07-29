using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

  private StationScript docked_at;
  private Map game_map;
  private int _scale;

  public Map map {
    get {
      return game_map;
    }
  }

  public int scale {
    get {
      return _scale;
    }
  }

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
    _scale = 1;
    game_map = Map.draw();
  }

  void Update() {
    set_asteroid_density();
    check_station_proximity();

    if (Input.GetKeyDown("m")) {
      GlobalObjects.ui.toggle_map();
    }

    // Cheaty cheats
    if (Input.GetKeyDown("r")) {
      GlobalObjects.ship_spawner.make_random_ship(Team.pirates);
    }
    if (Input.GetKeyDown("t")) {
      GlobalObjects.ship_spawner.make_random_ship(Team.team1);
    }
    if (Input.GetKeyDown("y")) {
      CargoFactory.make_credits(TrigHelper.random_location(player_position, 5), 50);
    }
  }

  private void set_asteroid_density() {
    GlobalObjects.asteroid_spawner.density = map.density_at(player_position);
  }

  private void check_station_proximity() {
    GlobalObjects.ship_spawner.spawn_station(map.station_at(player_position));
  }

  public void start_game() {
    ShipFactory.make_player(new Vector2(0, 0), 0);
    set_scale_for_player();
  }

  public void scale_is(int scale) {
    GlobalObjects.camera_control.set_scale(scale);
    _scale = scale;
  }

  public void dock(StationScript station) {
    docked_at = station;
    GlobalObjects.ui.open_station_menu(station);
    Game.pause();
  }

  public void undock() {
    GlobalObjects.player.destroy();
    ShipFactory.make_player(docked_at.undock_position, docked_at.undock_rotation);
    set_scale_for_player();
    GlobalObjects.ui.close_station_menu();
    Game.unpause();
  }

  private void set_scale_for_player() {
    scale_is(GlobalObjects.player.ship_scale);
  }

  public void clear_world() {
    GlobalObjects.asteroid_spawner.clear();
    GlobalObjects.ship_spawner.clear();
  }
}
