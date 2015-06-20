using UnityEngine;
using System.Collections;

public class MeshScript : FadingScript {
  
  private Mesh mesh {
    get {
      return GetComponent<MeshFilter>().mesh;
    }
  }
  
  public override void set_color(Color color) {
    Color[] colors = new Color[mesh.vertices.Length];
    for (int i = 0; i < colors.Length; i++) {
        colors[i] = color;
    }
    mesh.colors = colors;
    this.color = color;
  }
}
