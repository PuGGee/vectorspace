using UnityEngine;
using System.Collections;

public class Explosive : Projectile {

  public static Color explosion_color = new Color(1f, 0.9f, 0.21f, 1);

  protected void explode(Collider2D collider) {
    Vector2 position = transform.position;
    position -= GetComponent<Rigidbody2D>().velocity * Time.deltaTime;
    transform.position = position;

    Impact impact = Projectile.make_impact(collider, transform.position, Vector2.zero, power, power);
    impact.velocity = GetComponent<Rigidbody2D>().velocity * (0.05f + Random.value * 0.1f);

    impact.explosion = true;
    impact.explosion_size = explosion_size;

    impact.cloud = explosion_cloud;
    impact.cloud_size = explosion_size * 3;
    impact.cloud_color = spark_color;

    ImpactFactory.inflict_impact(impact);
    Destroy(gameObject);
    
    // Vector2 position = transform.position;
    // position -= rigidbody2D.velocity * Time.deltaTime;
    // transform.position = position;
    // ExplosionFactory.make(power / 5, transform.position, velocity, power / 3, spark_color);
    // Destroy(gameObject);
  }

  void OnTriggerEnter2D (Collider2D collider) {
    if (not_friend(collider.transform) && !collider.isTrigger) {
      explode(collider);
    }
  }
}
