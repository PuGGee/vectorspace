using UnityEngine;
using System.Collections;

public class MissileScript : Explosive {
  
  private MovementScript move_script {
    get {
      return GetComponent<MovementScript>();
    }
  }
  
  void Start () {
    Destroy(gameObject, 10);
  }
  
  public void set_acceleration_and_direction(float acceleration, float angle_rads) {
    move_script.acceleration = acceleration;
    transform.localEulerAngles = new Vector3(0, 0, angle_rads * Mathf.Rad2Deg);
  }
  
  void OnTriggerEnter2D (Collider2D collider) {
    if (not_friend(collider.transform) && !collider.isTrigger) {
      explode();
    }
  }
}
