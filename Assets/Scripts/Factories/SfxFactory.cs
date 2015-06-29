using UnityEngine;
using System.Collections;

public class SfxFactory : Factory {
  
  public static void make_spark(Vector2 normal, Vector2 position, float max_speed, Color? color = null) {
    var normal_angle_rads = Mathf.Atan2(normal.y, normal.x);
    var spark_angle_rads = normal_angle_rads + Random.value * Mathf.PI - Mathf.PI / 2;
    
    var transform = make_object(GlobalPrefabs.find.spark, GlobalObjects.sfx_layer, position);
    
    var spark_script = transform.GetComponent<SparkScript>();
    spark_script.set_color(new Color(1, 0, 0, 1));
    spark_script.set_maxspeed_and_direction(max_speed, spark_angle_rads);
    if (color.HasValue) {
      spark_script.set_color(color.Value);
    }
  }
  
  public static void make_line(Vector2 start, Vector2 end, Color? color = null) {
    var transform = make_object(GlobalPrefabs.find.line, GlobalObjects.sfx_layer, Vector2.zero);
    
    var line_script = transform.GetComponent<LineScript>();
    line_script.set_from_to(start, end);
    line_script.set_duration(1);
    line_script.set_width(0.15f);
    if (color.HasValue) {
      line_script.set_color(color.Value);
    }
  }
  
  public static void make_explosion(Vector3 position, float scale, Vector2 velocity, Color? color = null) {
    var transform = make_object(GlobalPrefabs.find.explosion_cloud, GlobalObjects.sfx_layer, position - new Vector3(0, 0, Random.value));
    
    var explosion_cloud_script = transform.GetComponent<ExplosionCloudScript>();
    explosion_cloud_script.set_scale(scale);
    explosion_cloud_script.set_velocity(velocity);
    if (color.HasValue) {
      explosion_cloud_script.set_color(color.Value);
    }
  }
  
  public static void make_polygon(Vector2[] vertices, Vector2 velocity, Color color) {
    var transform = make_object(GlobalPrefabs.find.explosion_mesh, GlobalObjects.sfx_layer, new Vector3(0, 0, Random.value));
    
    transform.GetComponent<MeshFilter>().mesh = MeshFactory.make_mesh(vertices);
    
    MeshScript mesh_script = transform.GetComponent<MeshScript>();
    mesh_script.set_color(color);
    mesh_script.set_duration(100);
    mesh_script.set_velocity(velocity);
  }
}
