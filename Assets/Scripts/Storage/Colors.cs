using System;
using UnityEngine;
using System.Collections;

public class Colors : MonoBehaviour {

  public static ColorRecord[] _color_records {
    get; set;
  }

  public ColorRecord[] color_records;

  public static Color get(string name) {
    foreach (ColorRecord color_record in _color_records) {
      if (color_record.name == name) { return color_record.color; }
    }
    throw new Exception("That color doesn't exist");
  }

  [System.Serializable]
  public class ColorRecord : System.Object {
    public string name;
    public Color color;
  }

  void Start() {
    _color_records = color_records;
  }
}
