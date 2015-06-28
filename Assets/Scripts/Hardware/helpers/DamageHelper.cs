using UnityEngine;
using System.Collections;

public class DamageHelper {

  public static void damage(Damageable target, float damage_amount, Vector2 location, Vector2 normal) {
    target.damage(damage_amount);
    SparkHelper.spark_fountain(location, normal, (int)damage_amount, target.damage_color);
  }
}
