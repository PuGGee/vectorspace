using UnityEngine;
using System.Collections;

public class GlobalSounds : MonoBehaviour {

  public AudioClip crunch_sound;
  public AudioClip ship_explosion;

  private static GlobalSounds instance;

  public static GlobalSounds find {
    get {
      if (!instance) {
        instance = GameObject.Find("Prefabs").GetComponent<GlobalSounds>();
      }
      return instance;
    }
  }
}
