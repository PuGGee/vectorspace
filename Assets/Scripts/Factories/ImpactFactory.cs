using UnityEngine;
using System.Collections;

public class ImpactFactory : Factory {

  public static void inflict_impact(Impact impact) {
    SparkHelper.spark_fountain(impact.location, impact.normal, impact.spark_count, impact.spark_color);
    if (impact.explosion) SfxFactory.make_explosion(impact.location, impact.explosion_size, impact.velocity);
    if (impact.cloud) ExplosionFactory.make_cloud(impact.cloud_size, impact.location, impact.velocity, impact.damage, impact.cloud_color);
    if (impact.target) impact.target.damage(impact.damage);
  }
}
