using UnityEngine;
using System.Collections;

public class Scale {

  private static int _value;

  public static int value {
    get {
      return _value;
    }
  }

  public static void set(int value) {
    _value = value;
  }
}
