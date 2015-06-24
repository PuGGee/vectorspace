using UnityEngine;
using System.Collections;

public abstract class FadingScript : SfxScript {
  
  protected Color color;
  protected Color fade_color;
  
  void Start() {
    if (fade_color == null) set_duration(60);
    if (color == null) color = new Color(1, 0, 0, 1);
  }
  
  void FixedUpdate() {
    if (color.a <= fade_color.a) {
      Destroy(gameObject);
      return;
    }
    color -= fade_color;
    set_color(color);
  }
  
  public void set_duration(float time) {
    fade_color = new Color(0, 0, 0, 1 / time);
  }
}
