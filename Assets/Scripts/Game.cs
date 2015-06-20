using UnityEngine;
using System.Collections;

public class Game {

  public static void new_game() {
    PlayerData.credits = 300;
    PlayerData.ship = GlobalPrefabs.find.ship2;
    PlayerData.add_equipment(0, GlobalPrefabs.find.weapon2);
    PlayerData.add_equipment(1, GlobalPrefabs.find.weapon3);
    PlayerData.add_equipment(5, GlobalPrefabs.find.weapon3);
    PlayerData.add_equipment(6, GlobalPrefabs.find.weapon3);
    PlayerData.add_equipment(2, GlobalPrefabs.find.shield_gen1);
    PlayerData.add_equipment(3, GlobalPrefabs.find.armour1);
    PlayerData.add_equipment(4, GlobalPrefabs.find.armour1);
    
    ShipFactory.make_player(new Vector2(0, 0));
  }
  
  public static void pause() {
    Time.timeScale = 0;
  }
  
  public static void unpause() {
    Time.timeScale = 1;
  }
}
