using UnityEngine;
using System.Collections;

public abstract class Projectile : MonoBehaviour {
  
  private float power_value;
  
  protected Transform friend;
  
  protected Color color;
  
  public Transform shooter {
    set {
      friend = value;
    }
  }
  
  public float power {
    get {
      return power_value;
    }
    set {
      power_value = value;
    }
  }
  
  public static void make_impact(Collider2D target, Vector2 position, Vector2 normal, float force, float damage) {
    var damage_script = target.GetComponent<DamageScript>();
    var shield_script = target.GetComponent<ShieldScript>();
    if (shield_script != null) {
      shield_script.damage(damage);
      target.transform.parent.rigidbody2D.AddForceAtPosition(-normal * force * 10, position);
    } else {
      if (damage_script != null) {
        damage_script.damage(damage);
      }
      target.rigidbody2D.AddForceAtPosition(-normal * force * 10, position);
    }
  }
  
  public virtual void set_speed_and_direction(float speed, float angle_rads) {
    RigidbodyHelper.add_velocity(rigidbody2D, speed, angle_rads);
  }
  
  public virtual void set_color(Color color) {
    this.color = color;
    this.color.a = 1f;
  }
  
  protected void impact(Collider2D target, Vector2 position, Vector2 normal) {
    make_impact(target, position, normal, power / 3, power);
    
    for (int i = 0; i < 5; i++) {
      SfxFactory.make_spark(normal, position);
    }
  }
  
  protected bool not_friend(Transform target) {
    if (target.GetComponent<ShieldScript>()) {
      return target.parent != friend;
    } else {
      return target != friend;
    }
  }
}
