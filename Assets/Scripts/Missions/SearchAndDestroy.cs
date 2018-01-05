using UnityEngine;
using System.Collections;

public class SearchAndDestroy : Mission {

  private ArrayList target_ships;

  public SearchAndDestroy(Vector2 v, int i) : base(v, i) {}

  public override void initialize() {
    target_ships = new ArrayList();
    for (int i = 0; i < level; i++) {
      var control = GlobalObjects.ship_spawner.make_random_ship(
        Team.pirates,
        location + new Vector2(Random.value * 20 - 10, Random.value * 20 - 10),
        cull: false
      );
      target_ships.Add(control.gameObject);
    }
  }

  public override bool test_win_conditions() {
    foreach (GameObject ship in target_ships.Clone() as ArrayList) {
      if (ship == null) {
        target_ships.Remove(ship);
      }
    }
    return target_ships.Count <= 0;
  }
}
