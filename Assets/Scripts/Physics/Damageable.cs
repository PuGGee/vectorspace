using UnityEngine;
using System.Collections;

public abstract class Damageable : MonoBehaviour {

  private const float damage_multiplier = 3;

  public abstract Color damage_color { get; }

  public abstract void damage(float magnitude);

  void OnCollisionEnter2D(Collision2D collision) {
    if (collision.transform.GetComponent<CargoScript>()) return;
    var relative_mass = Mathf.Min(RigidbodyHelper.rigidbody_for(collision.transform).mass, RigidbodyHelper.rigidbody_for(transform).mass);
    float severity =  Mathf.Abs(Vector2.Dot(collision.relativeVelocity, collision.contacts[0].normal)) * relative_mass * damage_multiplier;

    SoundFactory.make_sound(transform.position, GlobalSounds.find.crunch_sound,
                            severity / 500,
                            Random.Range(0.8f, 1.2f));

    damage(severity);
  }
}
