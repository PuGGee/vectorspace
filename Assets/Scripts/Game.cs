using UnityEngine;
using System.Collections;

public class Game {

  public static void new_game() {
    PlayerData.credits = 100;
    PlayerData.ship = GlobalPrefabs.find.ship3;
    PlayerData.add_equipment(0, GlobalPrefabs.find.heavy_plasma_mkiii);
    PlayerData.add_equipment(1, GlobalPrefabs.find.heavy_plasma_mkiii);
    PlayerData.add_equipment(5, GlobalPrefabs.find.heavy_plasma_mkiii);
    // PlayerData.add_equipment(2, GlobalPrefabs.find.heavy_machinegun);
    // PlayerData.add_equipment(3, GlobalPrefabs.find.heavy_machinegun);
    // PlayerData.add_equipment(4, GlobalPrefabs.find.heavy_machinegun);
    // PlayerData.add_equipment(5, GlobalPrefabs.find.heavy_machinegun);
    PlayerData.add_equipment(6, GlobalPrefabs.find.lazor_mkiii);
    
    GlobalObjects.game_control.start_game();
  }
  
  public static void pause() {
    Time.timeScale = 0;
  }
  
  public static void unpause() {
    Time.timeScale = 1;
  }
}
