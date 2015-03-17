using UnityEngine;
using System.Collections;

public class Blueprint {

  private Transform ship_transform;
  public Transform[] equipment;
  
  public Transform ship_prefab {
    set {
      ship_transform = value;
      equipment = new Transform[ShipHelper.hardpoints(ship_transform).Length];
    }
  }
  
  public Blueprint() {
  }
  
  public void add_equipment(int index, Transform item) {
    equipment[index] = item;
  }
  
  public Transform make() {
    var instantiated_transform = GameObject.Instantiate(ship_transform) as Transform;
    instantiated_transform.parent = GlobalObjects.foreground;
    Vector3 position = instantiated_transform.localPosition;
    position.z = 0;
    
    return instantiated_transform;
  }
}
