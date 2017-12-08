using UnityEngine;
using System.Collections;

public class ShipSpawner : Spawner {

  const float ship_spawn_chance = 0.2f;

  bool station_present;
  Timer ship_spawn_interval_timer;

  public AIControl make_random_ship(Team.Faction team, Vector2 location) {
    var bp = new Blueprint();
    bp.ship_prefab = GlobalPrefabs.find.ship1;
    var weapon = new Transform[] {
      GlobalPrefabs.find.lazor_mki,
      GlobalPrefabs.find.lazor_mkii,
      // GlobalPrefabs.find.lazor_mkiii,
      GlobalPrefabs.find.light_machinegun,
      GlobalPrefabs.find.machinegun,
      GlobalPrefabs.find.heavy_machinegun,
      GlobalPrefabs.find.plasma_mki,
      GlobalPrefabs.find.plasma_mkii,
      GlobalPrefabs.find.plasma_mkiii
    }[Random.Range(0, 8)];
    bp.add_equipment(0, weapon);
    var equipment = new Transform[] {GlobalPrefabs.find.shield_gen1, GlobalPrefabs.find.armour1}[Random.Range(0, 2)];
    bp.add_equipment(2, equipment);

    return ShipFactory.make(bp, typeof(AIControl), team, location, 0) as AIControl;
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
      if (within_player_radius(ship.transform.localPosition)) {
        Destroy(ship);
      }
    }
  }

  private void populate_ships() {
    if (ship_spawn_interval_timer.interval()) {
      if (Random.value < ship_spawn_chance) {
        AIControl controller = make_random_ship(Team.team1);
        // controller.choose_random_waypoint();
      }
    }
  }
}
