using UnityEngine;
using System.Collections;

public class LazorScript : Projectile {
  
  private Vector2 direction;
  
  private LineRenderer line {
    get {
      return GetComponent<LineRenderer>();
    }
  }
  
  void Start () {
    line.useWorldSpace = false;
    line.SetPosition(1, direction * 100);
    line.SetColors(color, color);
    ray_trace();
    Destroy(gameObject, 0.1f);
  }
  
  private void ray_trace() {
    RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction);
    if (hits.Length > 0) {
      foreach (RaycastHit2D hit in hits) {
        if (not_friend(hit.collider.transform)) {
          impact(hit.collider, hit.point, hit.normal);
          line.SetPosition(1, transform.InverseTransformPoint(hit.point));
          break;
        }
      }
    }
  }
  
  public void set_direction(float angle_rads) {
    direction = TrigHelper.direction_from_angle(angle_rads);
  }
}
