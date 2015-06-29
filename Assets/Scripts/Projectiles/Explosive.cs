using UnityEngine;
using System.Collections;

public class Explosive : Projectile {
  
  protected void explode(Vector2 velocity) {
    Vector2 position = transform.position;
    position -= rigidbody2D.velocity * Time.deltaTime;
    transform.position = position;
    ExplosionFactory.make(power / 5, transform.position, velocity, power / 3, spark_color);
    Destroy(gameObject);
  }
  
  void OnTriggerEnter2D (Collider2D collider) {
    if (not_friend(collider.transform) && !collider.isTrigger) {
      // explode(collider.attachedRigidbody.velocity);
      explode(rigidbody2D.velocity * (0.05f + Random.value * 0.1f));
    }
  }
}
