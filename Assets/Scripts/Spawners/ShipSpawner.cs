using UnityEngine;
using System.Collections;

public class ShipSpawner : Spawner {

  const float ship_spawn_chance = 1f;

  bool station_present;
  Timer ship_spawn_interval_timer;

  public AIControl make_random_ship(Team.Faction team, Vector2 location, bool cull = true) {
    var bp = new Blueprint();
    var ship_prefab = random_ship();
    bp.ship_prefab = ship_prefab;
    var hardpoints = ship_prefab.GetComponent<ShipScript>().hardpoints;
    var weapon = random_weapon();
    for (int i = 0; i < hardpoints.Length; i++) {
      var hp = hardpoints[i];
      if (hp.is_weapon_point) {
        bp.add_equipment(i, weapon);
      } else {
        bp.add_equipment(i, random_hardware());
      }
    }

    return ShipFactory.make(bp, typeof(AIControl), team, location, 0, cull: cull) as AIControl;
  }

  public AIControl make_random_ship(Team.Faction team) {
    return make_random_ship(team, TrigHelper.random_location(GlobalObjects.player.position, spawn_start_distance));
  }

  public void spawn_station(Map.Station station) {
    if (station != null) {
      if (!station_present) {
        StationFactory.make(station.station_prefab, station.position);
        station_present = true;
      }
    } else {
      clear_stations();
      station_present = false;
    }
  }

  public void clear() {
    clear_ships();
    clear_stations();
  }

  private Transform random_ship() {
    return new Transform[] {
      GlobalPrefabs.find.ship1,
      GlobalPrefabs.find.ship2,
      GlobalPrefabs.find.ship3
    }[Random.Range(0, 3)];
  }

  private Transform random_weapon() {
    return new Transform[] {
      GlobalPrefabs.find.lazor_mki,
      GlobalPrefabs.find.lazor_mkii,
      // GlobalPrefabs.find.lazor_mkiii,
      GlobalPrefabs.find.light_machinegun,
      GlobalPrefabs.find.machinegun,
      GlobalPrefabs.find.heavy_machinegun,
      GlobalPrefabs.find.plasma_mki,
      GlobalPrefabs.find.plasma_mkii,
      GlobalPrefabs.find.heavy_plasma_mki,
      GlobalPrefabs.find.heavy_plasma_mkii
      // GlobalPrefabs.find.plasma_mkiii
    }[Random.Range(0, 8)];
  }

  private Transform random_hardware() {
    return new Transform[] {
      GlobalPrefabs.find.shield_gen1,
      GlobalPrefabs.find.armour1
    }[Random.Range(0, 2)];
  }

  private void clear_ships() {
    foreach (GameObject ship in all_ships()) {
      Destroy(ship);
    }
  }

  private void clear_stations() {
    foreach (GameObject station in all_stations()) {
      Destroy(station);
    }
  }

  void Start() {
    ship_spawn_interval_timer = new Timer(4);
  }

  void FixedUpdate() {
    cull_ships();
    populate_ships();
  }

  private GameObject[] all_ships() {
    return GameObject.FindGameObjectsWithTag("ship");
  }

  private GameObject[] all_stations() {
    return GameObject.FindGameObjectsWithTag("station");
  }

  private void cull_ships() {
    foreach (GameObject ship in all_ships()) {
      if (within_player_radius(ship.transform.localPosition) && ship.GetComponent<ShipScript>().cullable) {
        Destroy(ship);
      }
    }
  }

  private void populate_ships() {
    if (ship_spawn_interval_timer.interval()) {
      if (Random.value < ship_spawn_chance) {
        AIControl controller = make_random_ship(Team.team1);
        controller.choose_random_waypoint();

        controller = make_random_ship(Team.pirates);
        controller.choose_random_waypoint();
      }
    }
  }
}
