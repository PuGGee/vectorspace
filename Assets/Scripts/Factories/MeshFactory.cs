using UnityEngine;
using System.Collections;

public class MeshFactory {
  
  public static Mesh make_mesh(Vector2[] vertices2D) {
    Triangulator tr = new Triangulator(vertices2D);
    int[] indices = tr.Triangulate();

    Vector3[] vertices = new Vector3[vertices2D.Length];
    for (int i=0; i<vertices.Length; i++) {
        vertices[i] = new Vector3(vertices2D[i].x, vertices2D[i].y, 0);
    }

    Mesh mesh = new Mesh();
    mesh.vertices = vertices;
    mesh.triangles = indices;
    mesh.RecalculateNormals();
    mesh.RecalculateBounds();
    
    return mesh;
  }
}
