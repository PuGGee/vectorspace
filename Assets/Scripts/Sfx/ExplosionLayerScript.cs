using UnityEngine;
using System.Collections;

public class ExplosionLayerScript : SfxScript {
    
  public float shrink_rate;
  
  private SpriteRenderer sprite {
    get {
      return GetComponent<SpriteRenderer>();
    }
  }
  
  void FixedUpdate() {
    var new_scale = transform.localScale.x - shrink_rate;
    if (new_scale <= 0) {
      Destroy(gameObject);
    } else {
      transform.localScale = new Vector2(new_scale, new_scale);
    }
  }
  
  public override void set_color(Color color) {
    sprite.color = color;
  }
}
