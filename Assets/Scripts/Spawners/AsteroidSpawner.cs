using UnityEngine;
using System.Collections;

public class AsteroidSpawner : MonoBehaviour {
  
  public int field_radius;
  
  private int asteroid_max;
  private float roid_start_distance;
  
  public int density {
    get {
      return asteroid_max;
    }
    set {
      asteroid_max = value;
    }
  }
  
  void Start() {
    roid_start_distance = field_radius * 0.8f;
  }
  
  void Update () {
    Vector2 player_position = GlobalObjects.player.transform.localPosition;
    
    cull_roids(player_position);
    populate_roids(player_position);
  }
  
  public void clear() {
    foreach (GameObject roid in all_roids()) {
      Destroy(roid);
    }
  }
  
  private GameObject[] all_roids() {
    return GameObject.FindGameObjectsWithTag("asteroid");
  }
  
  private void cull_roids(Vector2 player_position) {
    foreach (GameObject roid in all_roids()) {
      Vector2 roid_position = roid.transform.localPosition;
      
      float x_diff = roid_position.x - player_position.x;
      float y_diff = roid_position.y - player_position.y;
      
      if (x_diff * x_diff + y_diff * y_diff >= field_radius * field_radius) {
        Destroy(roid);
      }
    }
  }
  
  private void populate_roids(Vector2 player_position) {
    int roid_count = GameObject.FindGameObjectsWithTag("asteroid").Length;
    
    for (int i = roid_count; i < asteroid_max; i++) {
      AsteroidFactory.make(roid_start_distance, 2, player_position);
    }
  }
}
