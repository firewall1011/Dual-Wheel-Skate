using UnityEngine;
using UnityEngine.SceneManagement;
using NaughtyAttributes;

[CreateAssetMenu]
public class SceneController : ScriptableObject
{
    [Scene]
    public int gameScene;
    [Scene]
    public int creditsScene;
    [Scene]
    public int menuScene;

    public void LoadMenuScene() => SceneManager.LoadScene(menuScene, LoadSceneMode.Single);
    public void LoadCreditsScene() => SceneManager.LoadScene(creditsScene, LoadSceneMode.Single);
    public void LoadGameScene() => SceneManager.LoadScene(gameScene, LoadSceneMode.Single);
}
