using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {
  
  public float acceleration;
  public float max_speed;
  public float turn_rate;
  public float max_turn_speed;
  
  public float rotation {
    get {
      return rigidbody2D.transform.eulerAngles.z + 90;
    }
  }
  
  public float rotation_rads {
    get {
      return rigidbody2D.transform.eulerAngles.z * Mathf.Deg2Rad + Mathf.PI / 2;
    }
  }
  
  public Vector2 direction {
    get {
      return new Vector2(Mathf.Cos(rotation_rads), Mathf.Sin(rotation_rads));
    }
  }
  
  public Vector2 velocity {
    get {
      return rigidbody2D.velocity;
    }
  }
  
  protected bool moving_too_fast {
    get {
      return rigidbody2D.velocity.sqrMagnitude >= max_speed * max_speed;
    }
  }
  
  protected bool turning_too_fast {
    get {
      return Mathf.Abs(rigidbody2D.angularVelocity) >= max_turn_speed;
    }
  }
  
  protected void thrust(float magnitude) {
    float x_component = Mathf.Cos(rotation_rads) * acceleration * magnitude;
    float y_component = Mathf.Sin(rotation_rads) * acceleration * magnitude;
    rigidbody2D.AddForce(new Vector2(x_component, y_component));
  }
  
  protected void roll(float magnitude) {
    rigidbody2D.AddTorque(turn_rate * magnitude);
  }
  
  protected void reduce_turnspeed() {
    float threshold = 0.3f * max_turn_speed;
    if (Mathf.Abs(rigidbody2D.angularVelocity) < threshold) {
      float fraction = -rigidbody2D.angularVelocity / threshold;
      roll(fraction);
    } else if (rigidbody2D.angularVelocity < 0) {
      roll(1);
    } else {
      roll(-1);
    }
  }
  
  protected void reduce_velocity() {
    Vector2 direction = -rigidbody2D.velocity.normalized;
    rigidbody2D.AddForce(direction * acceleration);
  }
  
  void FixedUpdate() {
    if (turning_too_fast) {
      reduce_turnspeed();
    }
    if (moving_too_fast) {
      reduce_velocity();
    }
  }
  
  public void turn_left(float magnitude = 1) {
    if (Mathf.Abs(magnitude) > 1) {
      magnitude = 1;
    }
    if (!turning_too_fast) {
      roll(Mathf.Abs(magnitude));
    }
  }
  
  public void turn_right(float magnitude = 1) {
    if (Mathf.Abs(magnitude) > 1) {
      magnitude = 1;
    }
    if (!turning_too_fast) {
      roll(-Mathf.Abs(magnitude));
    }
  }
  
  public void no_turn() {
    if (!turning_too_fast) {
      reduce_turnspeed();
    }
  }
  
  public void forward() {
    if (!moving_too_fast) {
      thrust(1);
    }
  }
  
  public void backward() {
    if (!moving_too_fast) {
      thrust(-0.5f);
    }
  }
}
