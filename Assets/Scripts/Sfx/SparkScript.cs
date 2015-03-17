using UnityEngine;
using System.Collections;

public class SparkScript : SfxScript {
  
  private const float damping_factor = 0.1f;
  
  private Vector2 damping;
    
  private TrailRenderer trail {
    get {
      return GetComponent<TrailRenderer>();
    }
  }
  
  void FixedUpdate() {
    if (rigidbody2D.velocity.sqrMagnitude <= damping.sqrMagnitude) {
      Destroy(gameObject);
      return;
    }
    rigidbody2D.velocity -= damping;
  }
  
  public override void set_color(Color color) {
    trail.material.SetColor("_TintColor", color);
  }
  
  public void set_maxspeed_and_direction(float max_speed, float angle_rads) {
    var speed = Random.value * max_speed * 0.8f + max_speed * 0.2f;
    RigidbodyHelper.set_velocity(rigidbody2D, speed, angle_rads);
    
    damping = rigidbody2D.velocity * damping_factor * (1 + Random.value);
  }
}
