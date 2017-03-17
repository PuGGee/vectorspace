using UnityEngine;
using System.Collections;

public class DamageScript : Damageable {

  public int structure;
  public int armour;
  
  private float current_structure;
  private float current_armour_top;
  private float current_armour_bottom;
  
  public const float ablation_multiplier = 0.02f;
  
  public override Color damage_color {
    get {
      return new Color(1, 0.6f, 0.1f, 1);
    }
  }
  
  public float structure_fraction {
    get {
      return current_structure / structure;
    }
  }
  
  public float armour_fraction {
    get {
      return (current_armour_bottom + current_armour_top) / (armour * 2);
    }
  }
  
  void Start() {
    reset();
  }
  
  void FixedUpdate() {
    if (dead) {
      explode();
    }
  }
  
  public void reset() {
    current_structure = structure;
    current_armour_top = armour;
    current_armour_bottom = armour;
  }
  
  public bool dead {
    get {
      return current_structure <= 0;
    }
  }
  
  public void explode() {
    Destroy(gameObject);
    ExplosionFactory.make(7, transform.position, GetComponent<Rigidbody2D>().velocity, 30, new Color(1, 0, 0, 1));
  }
  
  public override void damage(float magnitude) {
    if (shield_active()) { return; }
    float armour_gap = current_armour_top - current_armour_bottom;
    float deflection = Random.value * armour_gap + current_armour_top;
    float ablation;
    if (deflection < magnitude) {
      current_structure -= magnitude - deflection;
      ablation = deflection;
    } else {
      ablation = magnitude;
    }
    ablation *= ablation_multiplier;
    if (current_armour_bottom < ablation) {
      ablation -= current_armour_bottom;
      current_armour_bottom = 0;
    } else {
      current_armour_bottom -= ablation;
      return;
    }
    if (current_armour_top < ablation) {
      current_armour_top = 0;
    } else {
      current_armour_top -= ablation;
    }
  }
  
  private bool shield_active() {
    return transform.Find("Shield") != null && transform.Find("Shield").GetComponent<ShieldScript>().shield_active;
  }
}
