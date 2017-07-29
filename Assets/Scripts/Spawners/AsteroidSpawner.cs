using UnityEngine;
using System.Collections;

public class AsteroidSpawner : Spawner {

  private int asteroid_max;
  private int roid_scale;

  public int density {
    get {
      return asteroid_max;
    }
    set {
      asteroid_max = value;
    }
  }

  private float max_roid_size {
    get {
      return 2 * scale_factor;
    }
  }

  void Update () {
    cull_roids();
    populate_roids();
  }

  public void clear() {
    foreach (GameObject roid in all_roids()) {
      Destroy(roid);
    }
  }

  private GameObject[] all_roids() {
    return GameObject.FindGameObjectsWithTag("asteroid");
  }

  private void cull_roids() {
    foreach (GameObject roid in all_roids()) {
      if (within_player_radius(roid.transform.localPosition)) {
        Destroy(roid);
      }
    }
  }

  private void populate_roids() {
    int roid_count = GameObject.FindGameObjectsWithTag("asteroid").Length;

    for (int i = roid_count; i < asteroid_max; i++) {
      AsteroidFactory.make(spawn_start_distance, max_roid_size, player_position);
    }
  }
}
