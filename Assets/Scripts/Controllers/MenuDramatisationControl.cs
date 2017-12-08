using UnityEngine;
using System.Collections;

public class MenuDramatisationControl : GameControl {

  const int SCALE = 1;
  const int ASTEROID_DENSITY = 50;
  const int SPAWN_INTERVAL = 120;

  private int previous_spawn_time;

  public override int scale {
    get {
      return SCALE;
    }
  }

  protected override void Start() {
    GlobalObjects.asteroid_spawner.density = ASTEROID_DENSITY;
    previous_spawn_time = 0;
    GlobalObjects.player = GameObject.Find("FakePlayer").GetComponent<ShipControl>();
  }

  protected override void Update() {
    if (previous_spawn_time < Time.frameCount - SPAWN_INTERVAL) {
      previous_spawn_time = Time.frameCount;
      if (Random.value < 0.5) {
        GlobalObjects.ship_spawner.make_random_ship(Team.pirates);
      } else {
        GlobalObjects.ship_spawner.make_random_ship(Team.team1);
      }
    }
  }
}
