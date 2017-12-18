using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

  private StationScript docked_at;
  private Map game_map;
  private bool game_over_shown;

  public Map map {
    get {
      return game_map;
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

  protected virtual void Start() {
    Scale.set(1);
    game_map = Map.draw();
    Game.new_game();
    start_game();
  }

  protected virtual void Update() {
    if (GlobalObjects.player != null) {
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
    } else {
      if (!game_over_shown) {
        game_over_shown = true;
        GlobalObjects.ui.show_game_over();
      }
    }
  }

  public void start_game() {
    ShipFactory.make_player(new Vector2(0, 0), 0);
    set_scale_for_player();
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

  private void set_asteroid_density() {
    GlobalObjects.asteroid_spawner.density = map.density_at(player_position);
  }

  private void check_station_proximity() {
    GlobalObjects.ship_spawner.spawn_station(map.station_at(player_position));
  }

  private void set_scale_for_player() {
    Scale.set(GlobalObjects.player.ship_scale);
  }

  public void clear_world() {
    GlobalObjects.asteroid_spawner.clear();
    GlobalObjects.ship_spawner.clear();
  }

  public void main_menu() {
    SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
  }
}
