using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StationScript : MonoBehaviour {
  
  public List<Transform> possible_equipment;
  
  public List<Stock> current_stock { get; set; }
  
  private Transform undocker {
    get {
      return transform.Find("undocker");
    }
  }
  
  public Vector2 undock_position {
    get {
      return undocker.position;
    }
  }
  
  public float undock_rotation {
    get {
      return undocker.eulerAngles.z;
    }
  }
  
  void Start() {
    current_stock = new List<Stock>();
    var equipment_sample = ListHelper.sample(possible_equipment, 5);
    foreach (var equipment in equipment_sample) {
      current_stock.Add(new Stock(equipment as Transform, Random.Range(1, 4)));
    }
  }
  
  public void reduce_stock(Transform item) {
    var stock = find_stock_by_name(EquipmentHelper.name(item));
    stock.quantity -= 1;
    if (stock.quantity == 0) current_stock.Remove(stock);
  }
  
  public void increase_stock(Transform item) {
    var stock = find_stock_by_name(EquipmentHelper.name(item));
    if (stock != null) {
      stock.quantity += 1;
    } else {
      current_stock.Add(new Stock(item, 1));
    }
  }
  
  private Stock find_stock_by_name(string name) {
    foreach (var stock in current_stock) {
      if (EquipmentHelper.name(stock.stock_item) == name) return stock;
    }
    return null;
  }
  
  public class Stock {
    
    public int quantity { get; set; }
    public Transform stock_item { get; set; }
    
    public string name {
      get {
        return EquipmentHelper.name(stock_item) + " " + quantity;
      }
    }
    
    public Stock(Transform stock_item, int quantity) {
      this.stock_item = stock_item;
      this.quantity = quantity;
    }
  }
}
