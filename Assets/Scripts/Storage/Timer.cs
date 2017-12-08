public class Timer {

  const int frames_in_a_second = 30;

  private int counter;
  private int interval_size;

  public Timer(int interval_size_seconds) {
    counter = 0;
    this.interval_size = interval_size_seconds * frames_in_a_second;
  }

  public bool interval() {
    counter++;
    if (counter >= interval_size) {
      counter = 0;
      return true;
    } else {
      return false;
    }
  }
}
