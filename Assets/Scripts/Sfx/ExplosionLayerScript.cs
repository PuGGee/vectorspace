using UnityEngine;
using System.Collections;

public class ExplosionLayerScript : SfxScript {

  public float shrink_rate;

  private float actual_shrink_rate;

  private SpriteRenderer sprite {
    get {
      return GetComponent<SpriteRenderer>();
    }
  }

  void Awake() {
    actual_shrink_rate = shrink_rate;
  }

  void FixedUpdate() {
    var new_scale = transform.localScale.x - actual_shrink_rate;
    if (new_scale <= 0) {
      Destroy(gameObject);
    } else {
      transform.localScale = new Vector2(new_scale, new_scale);
    }
    actual_shrink_rate += shrink_rate / 10;
  }

  public override void set_color(Color color) {
  }
}
