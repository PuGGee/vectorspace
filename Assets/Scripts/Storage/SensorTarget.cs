using UnityEngine;
using System.Collections;

public class SensorTarget {
  private Transform transform_value;
  private float angle_value;
  private int age_value;
  private Vector2 hit_location;
  
  public Transform transform {
    get {
      return transform_value;
    }
  }
  
  public Vector2 location {
    get {
      return hit_location;
    }
  }
  
  public float angle {
    get {
      return angle_value;
    }
  }
  
  public int age {
    get {
      return age_value;
    }
    set {
      age_value = value;
    }
  }
  
  public void update_target(float angle_value, Vector2 hit_location) {
    this.angle_value = angle_value;
    this.hit_location = hit_location;
    age_value = 0;
  }
  
  public SensorTarget(Transform transform_value, Vector2 hit_location, float angle_value) {
    this.transform_value = transform_value;
    this.hit_location = hit_location;
    this.angle_value = angle_value;
  }
}
