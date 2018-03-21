using UnityEditor;

class Build {
  static void Perform() {
    var buildPlayerOptions = new BuildPlayerOptions();
    buildPlayerOptions.scenes = new[] {
      "Assets/Scenes/Main Menu.unity",
      "Assets/Scenes/Main Scene.unity"
    };
    buildPlayerOptions.locationPathName = "Dist/WebGL";
    buildPlayerOptions.target = BuildTarget.WebGL;
    buildPlayerOptions.options = BuildOptions.None;
    BuildPipeline.BuildPlayer(buildPlayerOptions);
  }
}
