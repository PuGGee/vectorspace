using UnityEngine;
using System.Collections;

public class LocationMarkersScript : MonoBehaviour {

  public int marker_scale;
  public Texture red_marker_texture;
  public Texture green_marker_texture;
  public Texture yellow_marker_texture;
  public float off_camera_multiplier_for_ships;
  public float off_camera_multiplier_for_stations;

  private Vector2 ellipse;

  private new Transform camera {
    get {
      return Camera.main.transform;
    }
  }

  private Vector2 camera_position {
    get {
      return camera.position;
    }
  }

  void Start() {
    ellipse = new Vector2(Screen.width * 0.9f / 2, Screen.height * 0.9f / 2);
  }

  void OnGUI() {
    draw_ship_markers();
    draw_station_markers();
    draw_mission_markers();
  }

  private void draw_ship_markers() {
    foreach (Transform ship in find_off_screen_ships()) {
      ShipScript ship_script = ship.GetComponent<ShipScript>();
      if (ship_script != null) {
        var texture = ship_script.team.enemy_of(GlobalObjects.player.team) ? red_marker_texture : green_marker_texture;
        draw_marker(find_intersection_for_object(ship), texture);
      }
    }
  }

  private void draw_station_markers() {
    foreach (Transform station in find_off_screen_stations()) {
      draw_marker(find_intersection_for_object(station), yellow_marker_texture);
    }
  }

  private void draw_mission_markers() {
    if (GlobalObjects.mission_control.mission_marker_enabled) {
      Vector2 mission_marker_location = find_intersection_for_point(GlobalObjects.mission_control.current_mission.location);
      draw_marker(mission_marker_location, red_marker_texture);
    }
  }

  private ArrayList find_off_screen_ships() {
    return find_off_screen_objects(ShipControl.ship_tag, off_camera_multiplier_for_ships);
  }

  private ArrayList find_off_screen_stations() {
    return find_off_screen_objects(StationControl.station_tag, off_camera_multiplier_for_stations);
  }

  private ArrayList find_off_screen_objects(string tag, float multiplier) {
    var result = new ArrayList();
    var objects = GameObject.FindGameObjectsWithTag(tag);
    foreach (var obj in objects) {
      Vector2 obj_position = obj.transform.position;
      Vector2 position = obj_position - camera_position;
      Vector2 rotated_position = Quaternion.Inverse(camera.rotation) * position;
      if (Mathf.Abs(rotated_position.x * Camera.main.GetComponent<Camera>().orthographicSize) >= ellipse.x * multiplier ||
          Mathf.Abs(rotated_position.y * Camera.main.GetComponent<Camera>().orthographicSize) >= ellipse.y * multiplier) {
        result.Add(obj.transform);
      }
    }
    return result;
  }

  private Vector2 find_intersection_for_point(Vector2 position) {
    Vector2 relative_position = Quaternion.Inverse(camera.rotation) * (position - camera_position);
    var width = ellipse.x;
    var height = ellipse.y;
    var ratio = Mathf.Abs(relative_position.y / relative_position.x);
    var x_intersect = Mathf.Sqrt(1 / (1 / (width * width) + ratio * ratio / (height * height)));
    var y_intersect = Mathf.Sqrt((1 - x_intersect * x_intersect / (width * width)) * height * height);

    if (relative_position.x < 0) x_intersect = -x_intersect;
    if (relative_position.y < 0) y_intersect = -y_intersect;
    return new Vector2(x_intersect + Screen.width / 2, -y_intersect + Screen.height / 2);
  }

  private Vector2 find_intersection_for_object(Transform obj) {
    return find_intersection_for_point(obj.position);
  }

  private void draw_marker(Vector2 position, Texture texture) {
    Vector2 direction = position - UIHelper.centre();
    var rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
    UIHelper.draw_marker(texture, position, rotation, marker_scale);
  }
}
