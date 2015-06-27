using UnityEngine;
using System.Collections;

public class GlobalPrefabs : MonoBehaviour {

  public Transform ship1;
  public Transform ship2;
  public Transform ship3;
  public Transform ship4;
  public Transform ship5;
  public Transform ship6;
  public Transform ship7;
  public Transform ship8;
  
  public Transform station1;
  
  public Transform weapon1;
  public Transform weapon2;
  public Transform weapon3;
  public Transform weapon4;
  public Transform weapon5;
  
  public Transform shield_gen1;
  public Transform armour1;
  public Transform engine1;
  
  public Transform tracer;
  public Transform lazor;
  public Transform missile;
  public Transform slug;
  
  public Transform spark;
  public Transform line;
  public Transform explosion_cloud;
  
  public Transform asteroid;
  
  public Transform explosion_mesh;
  
  private static GlobalPrefabs instance;
  
  public static GlobalPrefabs find {
    get {
      if (!instance) {
        instance = GameObject.Find("Prefabs").GetComponent<GlobalPrefabs>();
      }
      return instance;
    }
  }
}
