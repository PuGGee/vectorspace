using System;
using UnityEngine;

public class SoundDestroyer : MonoBehaviour {

  private AudioSource audio_source;

  void Awake() {
    audio_source = GetComponent<AudioSource>();
  }

  void Update() {
    if (!audio_source.isPlaying) Destroy(gameObject);
  }
}
