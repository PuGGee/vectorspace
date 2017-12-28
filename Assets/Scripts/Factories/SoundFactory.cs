using UnityEngine;
using System.Collections;

public class SoundFactory : Factory {

  public static void make_sound(Vector2 position, AudioClip sound_clip, float volume, Vector2 velocity = default(Vector2), bool adjust_pitch = true) {
    var transform = make_object(GlobalPrefabs.find.sound_prefab, GlobalObjects.sfx_layer, position);

    transform.GetComponent<Rigidbody2D>().velocity = velocity;

    var audio_source = transform.GetComponent<AudioSource>();
    audio_source.clip = sound_clip;
    audio_source.volume = volume;
    if (adjust_pitch) audio_source.pitch = Random.Range(0.4f, 1.6f);
    audio_source.Play();
  }
}
