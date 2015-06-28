using UnityEngine;
using System.Collections;

public class SparkScript : FadingScript {
  
  private const float damping_factor = 0.75f;
  
  private Vector2 damping;
  private Vector2 length;
    
  private LineScript line {
    get {
      return GetComponent<LineScript>();
    }
  }
  
  private Vector2 position {
    get {
      return transform.position;
    }
  }
  
  void Update() {
    line.set_from_to(position, position + length);
    rigidbody2D.velocity -= damping;
  }
  
  public override void set_color(Color color) {
    line.set_color(color);
    this.color = color;
  }
  
  public void set_maxspeed_and_direction(float max_speed, float angle_rads) {
    var speed = Mathf.Pow(Random.value, 4) * max_speed;
    RigidbodyHelper.set_velocity(rigidbody2D, speed, angle_rads);
    
    length = rigidbody2D.velocity * (0.35f + Random.value) / 25;
    
    damping = rigidbody2D.velocity.normalized * damping_factor;
    
    float duration = rigidbody2D.velocity.x / damping.x;
    set_duration(duration);
  }
}
