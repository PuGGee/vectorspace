using UnityEngine;
using System.Collections;

public class UIHelper {
  
  public static Vector2 centre {
    get {
      return new Vector2(Screen.width / 2, Screen.height / 2);
    }
  }
  
  public static void draw_marker(Texture texture, Vector2 position, float rotation, float scale) {
    GUIUtility.RotateAroundPivot(rotation, position);
    GUI.DrawTexture(new Rect(position.x - scale, position.y - scale, scale * 2, scale * 2), texture);
    GUIUtility.RotateAroundPivot(-rotation, position);
  }
}
