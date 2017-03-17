using UnityEngine;
using System.Collections;

public class Map {

  ArrayList as_field_list;
  ArrayList station_list;

  public static Map draw() {
    var map = new Map();
    map.add_asteroid_field(new Vector2(300, 0), 200, 80);
    map.add_asteroid_field(new Vector2(-300, 0), 200, 80);
    map.add_asteroid_field(new Vector2(0, 300), 200, 80);
    map.add_asteroid_field(new Vector2(0, -300), 200, 80);
    map.add_asteroid_field(new Vector2(300, 300), 200, 80);
    map.add_asteroid_field(new Vector2(-300, 300), 200, 80);
    map.add_asteroid_field(new Vector2(-300, -300), 200, 80);
    map.add_asteroid_field(new Vector2(300, -300), 200, 80);
    map.add_station(new Vector2(20, 0), GlobalPrefabs.find.station1);
    return map;
  }

  public ArrayList asteroid_fields {
    get {
      return as_field_list;
    }
  }

  public ArrayList stations {
    get {
      return station_list;
    }
  }

  public Map() {
    as_field_list = new ArrayList();
    station_list = new ArrayList();
  }

  public void add_asteroid_field(Vector2 position, int radius, int density) {
    asteroid_fields.Add(new AsteroidField(position, radius, density));
  }

  public void add_station(Vector2 position, Transform station_prefab) {
    stations.Add(new Station(position, station_prefab));
  }

  public int density_at(Vector2 position) {
    int max = 0;
    foreach (AsteroidField field in asteroid_fields) {
      int density = field.density_at(position);
      if (density > max) {
        max = density;
      }
    }
    return max;
  }

  public Station station_at(Vector2 position) {
    foreach (Station station in stations) {
      if (station.within_range_of(position)) return station;
    }
    return null;
  }

  public class AsteroidField {

    Vector2 centre_value;
    int square_radius_value;
    int _real_radius;
    int max_density;

    public Vector2 centre {
      get {
        return centre_value;
      }
    }

    public int radius {
      get {
        return square_radius_value;
      }
    }

    public int real_radius {
      get; set;
    }

    public int density {
      get {
        return max_density;
      }
    }

    public AsteroidField(Vector2 centre_value, int radius_value, int max_density) {
      this.centre_value = centre_value;
      square_radius_value = radius_value * radius_value;
      real_radius = radius_value;
      this.max_density = max_density;
    }

    public int density_at(Vector2 position) {
      Vector2 diff = position - centre;
      var distance = diff.sqrMagnitude;
      if (distance < square_radius_value) {
        return (int)Mathf.Round((1.0f - distance / square_radius_value) * max_density);
      } else {
        return 0;
      }
    }
  }

  public class Station {

    Vector2 position_data;
    Transform station_data;

    private const int sqr_distance = 4000;

    public Vector2 position {
      get {
        return position_data;
      }
    }

    public Transform station_prefab {
      get {
        return station_data;
      }
    }

    public Station(Vector2 position_data, Transform station_data) {
      this.position_data = position_data;
      this.station_data = station_data;
    }

    public bool within_range_of(Vector2 position) {
      return (this.position - position).sqrMagnitude <= sqr_distance;
    }
  }
}
