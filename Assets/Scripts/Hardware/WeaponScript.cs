using UnityEngine;
using System.Collections;

public class WeaponScript : Equipment {

  public int fire_rate;
  public float power;
  public WeaponType weapon_type;
  public float projectile_speed;
  public string _color;
  public string _spark_color;
  public AudioClip shooting_sound;
  public AudioClip impact_sound;
  public float explosion_size;
  public bool explosion_cloud;

  private int _timer;

  private Transform hardpoint_transform;
  private ShipScript ship_script;

  public float direction_rads { get; set; }

  public Color color {
    get {
      return Colors.get(_color);
    }
  }
  public Color spark_color {
    get {
      return Colors.get(_spark_color);
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

  public int timer {
    get {
      return _timer;
    }
  }

  public bool is_turret { get; set; }

  public Vector2 velocity {
    get {
      return transform.parent.GetComponent<Rigidbody2D>().velocity;
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
    gameObject.AddComponent<TurretControl>();
    gameObject.GetComponent<TurretControl>().weapon = this;
  }

  void Start() {
    _timer = fire_rate;
  }

  protected virtual void FixedUpdate() {
    _timer++;
  }

  public void pull_trigger() {
    if (_timer >= fire_rate) {
      shoot();
      _timer = 0;
    }
  }

  public void release_trigger(int timing_offset) {
    if (_timer >= fire_rate - timing_offset) {
      _timer = fire_rate - timing_offset;
    }
  }

  private void shoot() {
    if (shooting_sound) SoundFactory.make_sound(world_position, shooting_sound,
                                            0.02f,
                                            velocity,
                                            false);

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
