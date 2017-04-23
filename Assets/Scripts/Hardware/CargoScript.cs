using UnityEngine;
using System.Collections;

public class CargoScript : MonoBehaviour {

  public Transform loot_item { get; set; }
  public int loot_credits { get; set; }

  void OnCollisionEnter2D (Collision2D collision) {
    Collider2D collider = collision.collider;
    if (collider.GetComponent<PlayerControl>() != null) {
      if (loot_item != null) { PlayerData.inventory.Add(loot_item); }
      if (loot_credits != null) { PlayerData.credits += loot_credits; }
      Destroy(gameObject);
    }
  }
}
