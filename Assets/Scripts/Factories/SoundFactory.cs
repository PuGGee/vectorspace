using UnityEngine;
using System.Collections;

public class SoundFactory : Factory {

  public static void make_sound(Vector2 position, AudioClip sound_clip, float volume, float pitch) {
    var transform = make_object(GlobalPrefabs.find.sound_prefab, GlobalObjects.sfx_layer, position);

    var audio_source = transform.GetComponent<AudioSource>();
    audio_source.clip = sound_clip;
    audio_source.volume = volume;
    audio_source.pitch = pitch;
    audio_source.Play();
  }
}
