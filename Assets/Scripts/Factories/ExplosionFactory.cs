using UnityEngine;
using System.Collections;

public class ExplosionFactory : Factory {
  
  private static Color mesh_color_constant = new Color(0.44f, 0.44f, 0.44f, 1);
  
  public static void make(float scale, Vector2 position, Vector2 velocity, float damage, Color color) {
    int rays_count = (int)(scale * 5);
    var interval = Mathf.PI * 2 / rays_count;
    var offset = Random.value * interval;
    
    Vector2[] points = new Vector2[rays_count];
    for (int i = 0; i < rays_count; i++) {
      points[i] = trace_ray(i * interval + offset, position, scale, damage);
    }
    SfxFactory.make_polygon(points, velocity, color * mesh_color_constant);
    SfxFactory.make_explosion(position, 0.3f * scale, velocity, new Color(1f, 0.9f, 0.21f, 1));
  }
  
  private static Vector2 trace_ray(float angle_rads, Vector2 position, float max_length, float power) {
    var length = (Random.value + 1) * max_length / 2;
    var direction = TrigHelper.direction_from_angle(angle_rads);
    var hits = Physics2D.RaycastAll(position, direction, length);
    foreach (RaycastHit2D hit in hits) {
      if (hit.fraction > 0) {
        Projectile.make_impact(hit.collider, hit.point, hit.normal, power, power);
        return hit.point;
      }
    }
    return position + direction * length;
  }
}
