using UnityEngine;
using System.Collections;

public class MapUI : MonoBehaviour {
  
  public Texture asteroid_field_texture;
  public Texture player_marker_texture;
  public Texture station_marker_texture;
  public Texture mission_marker_texture;
  
  public float scale_factor;
  public float marker_scale;
  
  public float scale {
    get {
      return scale_factor;
    }
    set {
      scale_factor = value;
    }
  }

  private Map map {
    get {
      return GlobalObjects.game_control.map;
    }
  }
  
  private Vector2 position {
    get {
      return GlobalObjects.player.position;
    }
  }
  
  private Vector2 mission_position {
    get {
      return GlobalObjects.mission_control.current_mission.location;
    }
  }
  
  void OnGUI() {
    draw_background();
    draw_asteroid_fields();
    draw_station_markers();
    draw_mission_marker();
    draw_player_marker();
  }
  
  private Vector2 screen_location(float x, float y) {
    float screen_x = (x - position.x) * scale_factor + UIHelper.centre.x;
    float screen_y = (y - position.y) * scale_factor + UIHelper.centre.y;
    return new Vector2(screen_x, screen_y);
  }
  
  private void draw_background() {
    GUILayout.BeginArea(new Rect(Screen.width * 0.2f, Screen.height * 0.2f, Screen.width * 0.8f, Screen.height * 0.8f));
    GUILayout.EndArea();
  }
  
  private void draw_asteroid_fields() {
    foreach (Map.AsteroidField asteroid_field in map.asteroid_fields) {
      
      Vector2 corner = screen_location(asteroid_field.centre.x - asteroid_field.real_radius, asteroid_field.centre.y - asteroid_field.real_radius);
      
      float size = asteroid_field.real_radius * 2 * scale_factor;
      
      var rect = new Rect(corner.x, corner.y, size, size);
      GUI.DrawTexture(rect, asteroid_field_texture);
    }
  }
  
  private void draw_station_markers() {
    foreach (Map.Station station in map.stations) {
      UIHelper.draw_marker(station_marker_texture, screen_location(station.position.x, station.position.y), 0, marker_scale);
    }
  }
  
  private void draw_mission_marker() {
    if (GlobalObjects.mission_control.mission_marker_enabled) {
      UIHelper.draw_marker(mission_marker_texture, screen_location(mission_position.x, mission_position.y), 0, marker_scale);
    }
  }
  
  private void draw_player_marker() {
    UIHelper.draw_marker(player_marker_texture, UIHelper.centre, GlobalObjects.player.rotation_degrees + 180, marker_scale);
  }
}
