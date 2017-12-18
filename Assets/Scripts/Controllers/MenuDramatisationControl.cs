using UnityEngine;
using System.Collections;

public class MenuDramatisationControl : GameControl {

  const int SCALE = 1;
  const int ASTEROID_DENSITY = 50;
  const int SPAWN_INTERVAL = 60;

  private int previous_spawn_time;

  protected override void Start() {
    Scale.set(SCALE);
    GlobalObjects.asteroid_spawner.density = ASTEROID_DENSITY;
    previous_spawn_time = 0;
    GlobalObjects.player = GameObject.Find("FakePlayer").GetComponent<ShipControl>();
  }

  protected override void Update() {
    if (previous_spawn_time < Time.frameCount - SPAWN_INTERVAL) {
      previous_spawn_time = Time.frameCount;
      GlobalObjects.ship_spawner.make_random_ship(Team.pirates);
      GlobalObjects.ship_spawner.make_random_ship(Team.team1);
    }
  }
}
