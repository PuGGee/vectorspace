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
  
  public Transform lazor_mki;
  public Transform lazor_mkii;
  public Transform lazor_mkiii;
  
  public Transform light_machinegun;
  public Transform machinegun;
  public Transform heavy_machinegun;
  
  public Transform light_missile;
  public Transform homing_missile;
  public Transform heavy_missile;
  
  public Transform plasma_mki;
  public Transform plasma_mkii;
  public Transform plasma_mkiii;
  
  public Transform shield_gen1;
  public Transform armour1;
  public Transform engine1;
  public Transform shield_gen2;
  public Transform armour2;
  public Transform engine2;
  public Transform shield_gen3;
  public Transform armour3;
  public Transform engine3;
  
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
