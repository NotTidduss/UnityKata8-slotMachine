using UnityEngine.SceneManagement;

public class Slots_SceneMaster
{
    private static string gameSceneName = "1x_Slots_Game";

    public static void loadGameScene() => SceneManager.LoadScene(gameSceneName);
}
