using UnityEngine;
using System.Collections;

public class ShipSpawner : MonoBehaviour {
  
  bool station_present;
  
  public ShipControl make_random_ship(Team.Faction team) {
    var bp = new Blueprint();
    bp.ship_prefab = GlobalPrefabs.find.ship1;
    var weapon = new Transform[] {GlobalPrefabs.find.weapon1, GlobalPrefabs.find.weapon2, GlobalPrefabs.find.weapon3, GlobalPrefabs.find.weapon5}[Random.Range(0, 4)];
    bp.add_equipment(0, weapon);
    var equipment = new Transform[] {GlobalPrefabs.find.shield_gen1, GlobalPrefabs.find.armour1}[Random.Range(0, 2)];
    bp.add_equipment(2, equipment);
    
    return ShipFactory.make(bp, "AIControl", team, GlobalObjects.player.transform.position + new Vector3(Random.value * 20 - 10, Random.value * 20 - 10, 0));
  }
  
  public ShipControl make_random_ship(Team.Faction team, Vector2 location) {
    var bp = new Blueprint();
    bp.ship_prefab = GlobalPrefabs.find.ship1;
    bp.add_equipment(0, GlobalPrefabs.find.weapon3);
    
    return ShipFactory.make(bp, "AIControl", team, location);
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
    
  }
  
  private void populate_ships() {
    
  }
}
