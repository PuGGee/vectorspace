public class Team {

  public static Faction player = new Faction("player");
  public static Faction team1 = new Faction("team1");
  public static Faction team2 = new Faction("team2");
  public static Faction pirates = new Faction("pirates", -100);
  
  public class Faction {
    private int rep;
    private string faction_name;
    
    public int reputation {
      get {
        return rep;
      }
      set {
        rep = value;
        if (rep > 100) {
          rep = 100;
        } else if (rep < -100) {
          rep = -100;
        }
      }
    }
    
    public string name {
      get {
        return faction_name;
      }
    }
    
    public bool enemy_of(Faction other_team) {
      if (this == player) {
        if (other_team == player) return false;
        return other_team.enemy_of(this);
      } else if (other_team == player) {
        if (rep <= -10) {
          return true;
        } else {
          return false;
        }
      } else if (other_team != this) {
        return true;
      } else {
        return false;
      }
    }
    
    public Faction(string name, int rep = 0) {
      faction_name = name;
      this.rep = rep;
    }
  }
}
