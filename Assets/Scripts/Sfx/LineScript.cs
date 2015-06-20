using UnityEngine;
using System.Collections;

public class LineScript : FadingScript {
  
  private LineRenderer line {
    get {
      return GetComponent<LineRenderer>();
    }
  }
  
  public void set_from_to(Vector2 from, Vector2 to) {
    line.SetPosition(0, from);
    line.SetPosition(1, to);
  }
  
  public void set_width(float width) {
    line.SetWidth(width, width);
  }
  
  public override void set_color(Color color) {
    line.SetColors(color, color);
    this.color = color;
  }
}
