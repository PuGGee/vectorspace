using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

  public int field_radius;

  protected float scale_factor {
    get {
      return 0.5f + Scale.value * 0.5f;
    }
  }

  protected int scaled_field_radius {
    get {
      return (int)(field_radius * scale_factor);
    }
  }

  protected float spawn_start_distance {
    get {
      return scaled_field_radius * 0.8f;
    }
  }

  protected Vector2 player_position {
    get {
      return GlobalObjects.player.transform.localPosition;
    }
  }

  protected bool within_player_radius(Vector2 location) {
    float x_diff = location.x - player_position.x;
    float y_diff = location.y - player_position.y;

    return x_diff * x_diff + y_diff * y_diff >= scaled_field_radius * scaled_field_radius;
  }
}
