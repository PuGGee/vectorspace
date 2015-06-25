using UnityEngine;
using System.Collections;

public class ProjectileFactory : Factory {
  
  private static Transform make_projectile(WeaponScript shooter_script, Transform prefab) {
    return make_object(prefab, GlobalObjects.projectiles_layer, shooter_script.world_position, shooter_script.ship.velocity);
  }
  
  private static void join_scripts(WeaponScript shooter_script, Projectile projectile_script) {
    projectile_script.shooter = shooter_script.transform.parent;
    projectile_script.power = shooter_script.power;
    projectile_script.set_color(shooter_script.color, shooter_script.spark_color);
  }
  
  public static void make_tracer(WeaponScript shooter_script) {
    var transform = make_projectile(shooter_script, GlobalPrefabs.find.tracer);
    
    var tracer_script = transform.GetComponent<TracerScript>();
    tracer_script.set_speed_and_direction(shooter_script.projectile_speed, shooter_script.rotation_rads);
    join_scripts(shooter_script, tracer_script);
  }
  
  public static void make_lazor(WeaponScript shooter_script) {
    var transform = make_object(GlobalPrefabs.find.lazor, GlobalObjects.projectiles_layer, shooter_script.world_position);
    
    var lazor_script = transform.GetComponent<LazorScript>();
    lazor_script.set_direction(shooter_script.rotation_rads);
    join_scripts(shooter_script, lazor_script);
  }
  
  public static void make_missile(WeaponScript shooter_script) {
    var transform = make_projectile(shooter_script, GlobalPrefabs.find.missile);
    
    var missile_script = transform.GetComponent<MissileScript>();
    join_scripts(shooter_script, missile_script);
    missile_script.set_acceleration_and_direction(shooter_script.projectile_speed, shooter_script.rotation_rads - Mathf.PI / 2);
  }
  
  public static void make_slug(WeaponScript shooter_script) {
    var transform = make_projectile(shooter_script, GlobalPrefabs.find.slug);
    
    var slug_script = transform.GetComponent<SlugScript>();
    join_scripts(shooter_script, slug_script);
    slug_script.set_speed_and_direction(shooter_script.projectile_speed, shooter_script.rotation_rads);
  }
}
