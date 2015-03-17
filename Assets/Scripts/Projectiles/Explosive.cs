using UnityEngine;
using System.Collections;

public class Explosive : Projectile {
  
  protected void explode() {
    Vector2 position = transform.position;
    position -= rigidbody2D.velocity * Time.deltaTime;
    transform.position = position;
    ExplosionFactory.make(4, transform.position, power / 3);
    Destroy(gameObject);
  }
}
