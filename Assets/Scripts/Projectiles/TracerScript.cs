using UnityEngine;
using System.Collections;

public class TracerScript : Projectile {

  private bool collided;
  private bool terminate;

  private LineRenderer line {
    get {
      return GetComponent<LineRenderer>();
    }
  }

  private Vector2 line_vector {
    get {
      return GetComponent<Rigidbody2D>().velocity * Time.deltaTime;
    }
  }

  public Vector2 position {
    get {
      return transform.position;
    }
  }

  void Start () {
    Destroy(gameObject, 3);
    line.useWorldSpace = false;
    line.SetPosition(1, line_vector);
    line.SetColors(color, color);
    line.SetWidth(SfxFactory.line_width, SfxFactory.line_width);
  }

  void FixedUpdate() {
    if (!collided) {
      update_position();
      test_ray_collision();
    }
  }

  void Update() {
    if (terminate) Destroy(gameObject);
    if (collided) terminate = true;
  }

  private bool test_ray_collision() {
    RaycastHit2D[] hits = Physics2D.RaycastAll(position + line_vector, GetComponent<Rigidbody2D>().velocity, GetComponent<Rigidbody2D>().velocity.magnitude * Time.deltaTime);
    if (hits.Length > 0) {
      foreach (RaycastHit2D hit in hits) {
        if (not_friend(hit.collider.transform)) {
          impact(hit.collider, hit.point, hit.normal);
          line.SetPosition(1, line_vector * hit.fraction);
          return collided = true;
        }
      }
    }
    return false;
  }

  private void update_position() {
    line.SetPosition(1, GetComponent<Rigidbody2D>().velocity * Time.deltaTime);
  }
}
