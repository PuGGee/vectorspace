using UnityEngine;
using System.Collections;

public abstract class Damageable : MonoBehaviour {
  
  private const float damage_multiplier = 1;
  
  public abstract void damage(float magnitude);
  
  void OnCollisionEnter2D(Collision2D collision) {
    var relative_mass = Mathf.Min(RigidbodyHelper.rigidbody_for(collision.transform).mass, RigidbodyHelper.rigidbody_for(transform).mass);
    float severity =  Mathf.Abs(Vector2.Dot(collision.relativeVelocity, collision.contacts[0].normal)) * relative_mass * damage_multiplier;
    damage(severity);
  }
}
