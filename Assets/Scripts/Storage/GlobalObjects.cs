using UnityEngine;
using System.Collections;

public class GlobalObjects : MonoBehaviour {

  private static Transform foreground_cache;
  private static Transform projectiles_cache;
  private static Transform sfx_cache;

  private static AsteroidSpawner asteroid_spawner_cache;
  private static ShipSpawner ship_spawner_cache;
  private static GameControl game_control_cache;
  private static MissionControl mission_control_cache;
  private static CameraControl camera_control_cache;
  private static UIControl ui_control_cache;

  private static Colors _colors;

  private static ShipControl player_cache;

  private static GameHUD hud_cache;
  private static StationMenu station_menu_cache;

  public static Transform foreground {
    get {
      return foreground_cache;
    }
  }

  public static Transform projectiles_layer {
    get {
      return projectiles_cache;
    }
  }

  public static Transform sfx_layer {
    get {
      return sfx_cache;
    }
  }

  public static AsteroidSpawner asteroid_spawner {
    get {
      return asteroid_spawner_cache;
    }
  }

  public static ShipSpawner ship_spawner {
    get {
      return ship_spawner_cache;
    }
  }

  public static ShipControl player {
    get {
      return player_cache;
    }
    set {
      player_cache = value;
    }
  }

  public static GameControl game_control {
    get {
      return game_control_cache;
    }
  }

  public static MissionControl mission_control {
    get {
      return mission_control_cache;
    }
  }

  public static CameraControl camera_control {
    get {
      return camera_control_cache;
    }
  }

  public static UIControl ui {
    get {
      return ui_control_cache;
    }
  }

  public static Colors colors {
    get {
      return _colors;
    }
  }

  private static Transform get_transform(string name) {
    return GameObject.Find(name).transform;
  }

  void Awake() {
    foreground_cache = get_transform("Foreground");
    projectiles_cache = get_transform("Projectiles");
    sfx_cache = get_transform("Sfx");

    asteroid_spawner_cache = GameObject.Find("EntityHandler").GetComponent<AsteroidSpawner>();
    ship_spawner_cache = GameObject.Find("EntityHandler").GetComponent<ShipSpawner>();
    game_control_cache = GameObject.Find("GameController").GetComponent<GameControl>();
    mission_control_cache = GameObject.Find("GameController").GetComponent<MissionControl>();
    camera_control_cache = GameObject.Find("MainCamera").GetComponent<CameraControl>();
    camera_control_cache = GameObject.Find("MainCamera").GetComponent<CameraControl>();

    ui_control_cache = GameObject.Find("GUIHandler").GetComponent<UIControl>();

    _colors = GetComponent<Colors>();
  }
}
