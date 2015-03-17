using UnityEngine;
using System.Collections;

public class TracerScript : Projectile {
  
  private LineRenderer line {
    get {
      return GetComponent<LineRenderer>();
    }
  }
  
  void Start () {
    Destroy(gameObject, 3);
    line.useWorldSpace = false;
    line.SetPosition(1, rigidbody2D.velocity * Time.deltaTime);
    line.SetColors(color, color);
  }
  
  void Update() {
    line.SetPosition(1, rigidbody2D.velocity * Time.deltaTime);
  }
  
  void FixedUpdate() {
    RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, rigidbody2D.velocity, rigidbody2D.velocity.magnitude * Time.deltaTime);
    if (hits.Length > 0) {
      foreach (RaycastHit2D hit in hits) {
        if (not_friend(hit.collider.transform)) {
          impact(hit.collider, hit.point, hit.normal);
          Destroy(gameObject);
          break;
        }
      }
    }
  }
}
