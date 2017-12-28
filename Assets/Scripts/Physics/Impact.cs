using UnityEngine;
using System.Collections;

public class Impact {

  public Damageable target { get; set; }
  public float      damage { get; set; }
  public Vector2    location { get; set; }
  public Vector2    normal { get; set; }

  public Vector2    velocity { get; set; }

  public int   spark_count { get; set; }
  public float spark_size { get; set; }
  public Color spark_color { get; set; }

  public bool  explosion { get; set; }
  public float explosion_size { get; set; }

  public bool  cloud { get; set; }
  public float cloud_size { get; set; }
  public Color cloud_color { get; set; }

  public AudioClip sound { get; set; }

  public Impact() {
    spark_count = 0;
    explosion = false;
    cloud = false;

  }

  public enum DamageType {
    standard,
    energy,
    explosive
  }
}
