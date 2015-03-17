using UnityEngine;
using System.Collections;

public class SlugScript : Explosive {
  
  private SpriteRenderer sprite {
    get {
      return GetComponent<SpriteRenderer>();
    }
  }
  
  void Start () {
    Destroy(gameObject, 10);
    sprite.color = color;
  }
  
  void OnTriggerEnter2D (Collider2D collider) {
    if (not_friend(collider.transform) && !collider.isTrigger) {
      explode();
    }
  }
  
  public override void set_speed_and_direction(float speed, float angle_rads) {
    base.set_speed_and_direction(speed, angle_rads);
    transform.eulerAngles = new Vector3(0, 0, angle_rads * Mathf.Rad2Deg + 90);
  }
}
