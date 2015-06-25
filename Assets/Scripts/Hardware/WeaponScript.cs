using UnityEngine;
using System.Collections;

public class WeaponScript : Equipment {
  
  public int fire_rate;
  public float power;
  public WeaponType weapon_type;
  public float projectile_speed;
  public Color color;
  public Color spark_color;
  
  private int timer;
  
  private Transform hardpoint_transform;
  private ShipScript ship_script;
  
  private float direction_rads_value;
  private bool is_turret;
  
  public float direction_rads {
    get {
      return direction_rads_value;
    }
    set {
      direction_rads_value = value;
    }
  }
  
  public Transform hardpoint {
    get {
      return hardpoint_transform;
    }
    set {
      hardpoint_transform = value;
    }
  }
  
  public HardpointScript hardpoint_script {
    get {
      return hardpoint.GetComponent<HardpointScript>();
    }
  }
  
  public ShipScript ship {
    get {
      if (!ship_script) {
        ship_script = transform.parent.GetComponent<ShipScript>();
      }
      return ship_script;
    }
  }
  
  public virtual float rotation_rads {
    get {
      if (is_turret) {
        return direction_rads;
      } else {
        return ship.rotation_rads;
      }
    }
  }
  
  public Vector2 world_position {
    get {
      return hardpoint_transform.position;
    }
  }
  
  public void set_turret() {
    is_turret = true;
    gameObject.AddComponent("TurretControl");
    gameObject.GetComponent<TurretControl>().weapon = this;
  }
  
  void Start() {
    timer = 0;
  }
  
  protected virtual void FixedUpdate() {
    timer++;
  }
  
  public void pull_trigger() {
    if (!is_turret) trigger();
  }
  
  public void turret_pull_trigger() {
    if (is_turret) trigger();
  }
  
  private void trigger() {
    if (timer >= fire_rate) {
      shoot();
      timer = 0;
    }
  }
  
  private void shoot() {
    switch (weapon_type) {
      case WeaponType.tracer:
        ProjectileFactory.make_tracer(this);
        break;
      case WeaponType.lazor:
        ProjectileFactory.make_lazor(this);
        break;
      case WeaponType.missile:
        ProjectileFactory.make_missile(this);
        break;
      case WeaponType.slug:
        ProjectileFactory.make_slug(this);
        break;
    }
  }
  
  public enum WeaponType {
    tracer,
    lazor,
    missile,
    slug
  }
}
