using UnityEngine;
using System.Collections;

public class ShieldScript : Damageable {

  public const string class_tag = "shield";
  
  private const float fade_rate = 0.04f;
  private const float overload_penalty = 0.5f;

  public int shield_strength;
  public float recharge_rate;
  
  private float current_strength;
  private float alpha;
  
  private bool overloaded;
  
  public override Color damage_color {
    get {
      return new Color(0.1f, 0.1f, 1, 1);
    }
  }
  
  public SpriteRenderer sprite {
    get {
      return GetComponent<SpriteRenderer>();
    }
  }
  
  public float shield_fraction {
    get {
      if (overloaded) {
        return 0;
      } else {
        return current_strength / shield_strength; 
      }
    }
  }
  
  public bool shield_active {
    get {
      return !overloaded;
    }
  }
  
  void Start() {
    reset();
  }
  
  public void reset() {
    current_strength = shield_strength;
    overloaded = false;
    alpha = 0;
  }
  
  public void remove() {
    Destroy(gameObject);
  }
  
  public override void damage(float magnitude) {
    current_strength -= magnitude;
    alpha = 1;
  }
  
  public void disable() {
    sprite.enabled = false;
    GetComponent<Collider2D>().enabled = false;
    overloaded = true;
    current_strength = -shield_strength * overload_penalty;
  }
  
  public void enable() {
    sprite.enabled = true;
    GetComponent<Collider2D>().enabled = true;
    overloaded = false;
  }
  
  void Update() {
    sprite.color = new Color(1, 1, 1, alpha);
  }
  
  void FixedUpdate() {
    check_if_overloaded();
    recharge();
    fade_sprite();
  }
  
  private void check_if_overloaded() {
    if (current_strength <= 0 && !overloaded) {
      disable();
    }
  }
  
  private void recharge() {
    if (shield_strength - current_strength <= recharge_rate) {
      current_strength = shield_strength;
      if (overloaded) {
        enable();
      }
    } else {
      current_strength += recharge_rate;
    }
  }
  
  private void fade_sprite() {
    if (alpha <= fade_rate) {
      alpha = 0;
    } else {
      alpha -= fade_rate;
    }
  }
}
