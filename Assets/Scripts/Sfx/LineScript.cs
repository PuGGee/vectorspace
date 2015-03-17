using UnityEngine;
using System.Collections;

public class LineScript : SfxScript {
  
  private Color color;
  private Color fade_color;
  
  private LineRenderer line {
    get {
      return GetComponent<LineRenderer>();
    }
  }
  
  void Start() {
    set_duration(60);
    color = new Color(1, 0, 0, 1);
  }
  
  void FixedUpdate() {
    if (color.a <= fade_color.a) {
      Destroy(gameObject);
      return;
    }
    color -= fade_color;
    line.SetColors(color, color);
  }
  
  public void set_from_to(Vector2 from, Vector2 to) {
    line.SetPosition(0, from);
    line.SetPosition(1, to);
  }
  
  public void set_duration(float time) {
    fade_color = new Color(0, 0, 0, 1 / time);
  }
  
  public void set_width(float width) {
    line.SetWidth(width, width);
  }
  
  public override void set_color(Color color) {
    line.SetColors(color, color);
    this.color = color;
  }
}
