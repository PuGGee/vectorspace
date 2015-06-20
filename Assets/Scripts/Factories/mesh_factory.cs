using UnityEngine;
using System.Collections;

public class MeshFactory {
  
  public static Transform make_mesh(Vector2[] vertices2D, Color color) {
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
    
    Transform mesh_renderer = GameObject.Instantiate(GlobalPrefabs.find.explosion_mesh) as Transform;
    
    mesh_renderer.GetComponent<MeshFilter>().mesh = mesh;
    
    MeshScript mesh_script = mesh_renderer.GetComponent<MeshScript>();
    mesh_script.set_color(color);
    mesh_script.set_duration(1);
    
    return mesh_renderer;
  }
}
