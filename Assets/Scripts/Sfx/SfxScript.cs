using UnityEngine;
using System.Collections;

public abstract class SfxScript : MonoBehaviour {
  
  public abstract void set_color(Color color);
  
  public void set_velocity(Vector2 velocity) {
    GetComponent<Rigidbody2D>().velocity = velocity;
  }
}
