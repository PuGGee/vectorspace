using UnityEngine;
using System.Collections;

public class UIHelper {

  public static Vector2 centre() {
    return new Vector2(Screen.width / 2, Screen.height / 2);
  }

  public static Vector2 centre(Rect screen_rect) {
    return new Vector2(screen_rect.width / 2, screen_rect.height / 2);
  }

  public static int gridx(int mult) {
    return Screen.width * mult / 12;
  }

  public static int gridy(int mult) {
    return gridx(mult);
  }

  public static int gridx(Rect screen_rect, int mult) {
    return (int)(screen_rect.width * mult / 12);
  }

  public static int gridy(Rect screen_rect, int mult) {
    return gridx(screen_rect, mult);
  }

  public static void draw_marker(Texture texture, Vector2 position, float rotation, float scale) {
    GUIUtility.RotateAroundPivot(rotation, position);
    GUI.DrawTexture(new Rect(position.x - scale, position.y - scale, scale * 2, scale * 2), texture);
    GUIUtility.RotateAroundPivot(-rotation, position);
  }

  public static bool button(string label, Rect rect) {
    var real_width = gridx((int)rect.width);
    var real_height = gridy((int)rect.height);
    var correctly_centred_rect = new Rect(rect.x - real_width / 2, rect.y - real_height / 2, real_width, real_height);
    return GUI.Button(correctly_centred_rect, label);
  }

  public static bool button(string label, int height) {
    return GUILayout.Button(label, GUILayout.Height(gridy(height)));
  }

  public static void show_group(Transform canvas_group_transform) {
    var canvas_group = canvas_group_transform.GetComponent<CanvasGroup>();
    canvas_group.alpha = 1;
    canvas_group.blocksRaycasts = true;
    canvas_group.interactable = true;
  }

  public static void hide_group(Transform canvas_group_transform) {
    var canvas_group = canvas_group_transform.GetComponent<CanvasGroup>();
    canvas_group.alpha = 0;
    canvas_group.blocksRaycasts = false;
    canvas_group.interactable = false;
  }
}
