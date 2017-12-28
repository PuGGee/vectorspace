using UnityEngine;
using System.Collections;

public class Explosive : Projectile {

  protected void explode(Collider2D collider) {
    if (impact_sound) {
      SoundFactory.make_sound(transform.position, impact_sound, 0.02f);
    } else {
      SoundFactory.make_sound(transform.position, GlobalSounds.find.ship_explosion, 0.02f);
    }

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
  }

  void OnTriggerEnter2D (Collider2D collider) {
    if (not_friend(collider.transform) && !collider.isTrigger) {
      explode(collider);
    }
  }
}
