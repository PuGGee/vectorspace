using UnityEngine;
using System.Collections;

public class ExplosionCloudScript : SfxScript {

  private const float layer_color_interval = 0.66f;

  private bool color_set;

  private ExplosionLayerScript layer(string identifier) {
    switch(identifier) {
      case "front":
        return transform.Find("Explosion Layer Front").GetComponent<ExplosionLayerScript>();
      case "middle":
        return transform.Find("Explosion Layer Middle").GetComponent<ExplosionLayerScript>();
      case "back":
        return transform.Find("Explosion Layer Back").GetComponent<ExplosionLayerScript>();
    }
    return null;
  }

  private ExplosionLayerScript[] layers {
    get {
      return GetComponentsInChildren<ExplosionLayerScript>();
    }
  }

  void Start() {
    if (!color_set) {
      set_color(Colors.get("explosion_color"));
    }
  }

  void Update() {
    if (layers.Length <= 0) {
      Destroy(gameObject);
    }
  }

  public void set_scale(float scale) {
    transform.localScale = new Vector3(scale, scale, 1);
  }

  public override void set_color(Color color) {
    layer("front").set_color(color);
    var middle_color = new Color(color.r * layer_color_interval, color.g * layer_color_interval, color.b * layer_color_interval, color.a);
    layer("middle").set_color(middle_color);
    var back_color = new Color(middle_color.r * layer_color_interval, middle_color.g * layer_color_interval, middle_color.b * layer_color_interval, color.a);
    layer("back").set_color(back_color);
    color_set = true;
  }
}
