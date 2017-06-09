using UnityEngine;
using System.Collections;

public abstract class Tab {

  protected StationMenu station_menu;
  protected Rect screen_rect;

  public Tab(StationMenu station_menu, Rect screen_rect) {
    this.station_menu = station_menu;
    this.screen_rect = screen_rect;
  }

  public int gridx(int mult) {
    return UIHelper.gridx(screen_rect, mult);
  }

  public int gridy(int mult) {
    return UIHelper.gridy(screen_rect, mult);
  }

  public Vector2 centre() {
    return UIHelper.centre(screen_rect);
  }

  public abstract void render();
}
