using UnityEngine;
using System.Collections;

public abstract class Mission {
  
  private const int start_distance = 60;
  
  private Vector2 location_data;
  private int bounty;
  private bool initialized;
  
  protected int level;
  
  public Vector2 location {
    get {
      return location_data;
    }
  }
  
  public int credits {
    get {
      return bounty;
    }
  }
  
  public bool started {
    get {
      return initialized;
    }
  }

  public Mission(Vector2 location_data, int level) {
    this.location_data = location_data;
    this.level = level;
    calculate_bounty();
    initialized = false;
  }
  
  private void calculate_bounty() {
    bounty = level * 100;
  }
  
  public void test_proximity() {
    if (!initialized) {
      float player_distance = (location_data - GlobalObjects.player.position).sqrMagnitude;
      if (player_distance <= start_distance * start_distance) {
        initialize();
        initialized = true;
      }
    }
  }
  
  public abstract void initialize();
  
  public abstract bool test_win_conditions();
}
