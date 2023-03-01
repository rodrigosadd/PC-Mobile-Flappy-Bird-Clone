using UnityEngine;
using UnityEngine.SceneManagement;

public class InitializationLoader : MonoBehaviour
{
    [Header("Game Scenes")]
    [SerializeField] private GameSceneSO _managersScene;
    [SerializeField] private GameSceneSO _mainMenuScene;

    void Start()
    {
        SceneManager.LoadSceneAsync(_managersScene.sceneName, LoadSceneMode.Additive).completed += LoadMainMenu;
    }

    void LoadMainMenu(AsyncOperation obj)
    {
        SceneManager.LoadSceneAsync(_mainMenuScene.sceneName, LoadSceneMode.Additive).completed += UnloadInitializationScene;
    }

    void UnloadInitializationScene(AsyncOperation obj)
    {
        SceneManager.UnloadSceneAsync(0);
    }
}
