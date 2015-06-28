using UnityEngine;
using System.Collections;

public class SparkHelper {

  public static void spark_fountain(Vector2 centre, Vector2 normal, int intensity, Color spark_color) {
    for (int i = 0; i < intensity; i++) {
      Debug.Log(spark_color);
      SfxFactory.make_spark(normal, centre, intensity * 4, spark_color);
    }
  }
}
