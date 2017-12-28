using UnityEngine;
using System.Collections;

public abstract class Projectile : MonoBehaviour {

  protected Transform friend;

  protected Color color;
  protected Color spark_color;

  public Transform shooter {
    set {
      friend = value;
    }
  }

  public float power { get; set; }

  public float explosion_size { get; set; }
  public bool explosion_cloud { get; set; }
  public AudioClip impact_sound { get; set; }

  public static Impact make_impact(Collider2D target, Vector2 position, Vector2 normal, float force, float damage) {
    var damage_script = target.GetComponent<DamageScript>();
    var shield_script = target.GetComponent<ShieldScript>();
    Impact impact = new Impact();
    if (shield_script != null) {
      impact.target = shield_script;
      target.transform.parent.GetComponent<Rigidbody2D>().AddForceAtPosition(-normal * force * 10, position);
    } else {
      if (damage_script != null) {
        impact.target = damage_script;
      }
      target.GetComponent<Rigidbody2D>().AddForceAtPosition(-normal * force * 10, position);
    }
    impact.location = position;
    impact.normal = normal;
    impact.damage = damage;
    return impact;
  }

  public virtual void set_speed_and_direction(float speed, float angle_rads) {
    RigidbodyHelper.add_velocity(GetComponent<Rigidbody2D>(), speed, angle_rads);
  }

  public virtual void set_color(Color color, Color spark_color) {
    this.color = color;
    this.color.a = 1f;
    this.spark_color = spark_color;
    this.spark_color.a = 1f;
  }

  protected void impact(Collider2D target, Vector2 position, Vector2 normal) {
    if (impact_sound) SoundFactory.make_sound(position, impact_sound, 0.04f);

    var impact = make_impact(target, position, normal, power / 6, power);
    ImpactFactory.inflict_impact(impact);

    SparkHelper.spark_fountain(position, normal, 7, spark_color);
  }

  public bool not_friend(Transform target) {
    if (target.GetComponent<ShieldScript>()) {
      return target.parent != friend;
    } else {
      return target != friend;
    }
  }
}
