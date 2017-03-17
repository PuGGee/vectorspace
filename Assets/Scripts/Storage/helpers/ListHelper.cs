using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ListHelper {

  public static T[] sample<T>(List<T> list, int sample_count) {
    List<T> list_copy = new List<T>(list);
    T[] result = new T[sample_count];
    for (int i = 0; i < sample_count; i++) {
      int rand = Random.Range(0, list_copy.Count);
      result[i] = list_copy[rand];
      list_copy.RemoveAt(rand);
    }
    return result;
  }
}
