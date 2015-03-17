using UnityEngine;
using System.Collections;

public abstract class Mission {
  
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
  
  public void start_mission() {
    if (initialized) { return; }
    initialize();
    initialized = true;
  }
  
  public abstract void initialize();
  
  public abstract bool test_win_conditions();
}
