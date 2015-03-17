using UnityEngine;
using System.Collections;

public abstract class Tab {
  
  protected StationMenu station_menu;
  
  public Tab(StationMenu station_menu) {
    this.station_menu = station_menu;
  }
  
  public abstract void render();
}
