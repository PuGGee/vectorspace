using UnityEngine;
using System.Collections;

public class AsteroidSpawner : MonoBehaviour {
  
  public int field_radius;
  
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
  
  private float scale_factor {
    get {
      return 0.5f + scale * 0.5f;
    }
  }
  
  private int scaled_field_radius {
    get {
      return (int)(field_radius * scale_factor);
    }
  }
  
  private float roid_start_distance {
    get {
      return scaled_field_radius * 0.8f;
    }
  }
  
  private float max_roid_size {
    get {
      return 2 * scale_factor;
    }
  }
  
  public int scale {
    get {
      return roid_scale;
    }
    set {
      roid_scale = value;
    }
  }
  
  void Start() {
    scale = 1;
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
      
      if (x_diff * x_diff + y_diff * y_diff >= scaled_field_radius * scaled_field_radius) {
        Destroy(roid);
      }
    }
  }
  
  private void populate_roids(Vector2 player_position) {
    int roid_count = GameObject.FindGameObjectsWithTag("asteroid").Length;
    
    for (int i = roid_count; i < asteroid_max; i++) {
      AsteroidFactory.make(roid_start_distance, max_roid_size, player_position);
    }
  }
}
