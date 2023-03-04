using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Header("Game Scene")]
    [SerializeField] private GameSceneSO _sceneAfterInitialization;

    [Header("Channels")]
    [SerializeField] private LoadEventChannelSO _locationLoadChannel;
    [SerializeField] private VoidEventChannelSO _startTransitionVoidChannel;
    [SerializeField] private VoidEventChannelSO _endTransitionVoidChannel;

    private bool _isLoading = false;
    private GameSceneSO _sceneToLoad = default;
    private GameSceneSO _currentlyLoadedScene = default;

    private void OnEnable()
    {
        _locationLoadChannel.OnLoadRequested += LoadScene;        

        _endTransitionVoidChannel.OnVoidRequested += UnloadPreviousScene;
    }

    private void OnDisable()
    {
        _locationLoadChannel.OnLoadRequested -= LoadScene;

        _endTransitionVoidChannel.OnVoidRequested -= UnloadPreviousScene;
    }

    void Start()
    {
        _currentlyLoadedScene = _sceneAfterInitialization;
    }

    void LoadScene(GameSceneSO scene)
    {
        if (_isLoading)
            return;

        _sceneToLoad = scene;
        _isLoading = true;

        _startTransitionVoidChannel.RaiseEvent();        
    }

    void UnloadPreviousScene()
    {
        if (_currentlyLoadedScene.ToString() != null)
        {            
            SceneManager.UnloadSceneAsync(_currentlyLoadedScene.sceneName);
        }

        LoadNewScene();
    }

    void LoadNewScene()
    {
        SceneManager.LoadSceneAsync(_sceneToLoad.sceneName, LoadSceneMode.Additive).completed += OnNewSceneLoaded;
    }
     
    void OnNewSceneLoaded(AsyncOperation obj)
    {
        _currentlyLoadedScene = _sceneToLoad;
        _isLoading = false;
    }
}
