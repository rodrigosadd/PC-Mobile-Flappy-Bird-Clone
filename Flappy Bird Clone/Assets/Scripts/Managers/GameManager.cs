using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [Header("Balancing")]
    [SerializeField] private BalancingContainerSO _balancingContainer;

    [Header("Lost")] 

    [SerializeField] private GameSceneSO _sceneAfterLost;

    [Header("Pause")]
    [SerializeField] private VoidEventChannelSO _pauseVoidChannel;
    [SerializeField] private VoidEventChannelSO _unpauseVoidChannel;

    [Header("Void Channels")]
    [SerializeField] private VoidEventChannelSO _collisionVoidChannel;
    [SerializeField] private VoidEventChannelSO _restartVoidChannel;
    [SerializeField] private VoidEventChannelSO _quitLoadChannel;
    [SerializeField] private VoidEventChannelSO _endTransitionVoidChannel;

    [Header("Bool Channels")]
    [SerializeField] private BoolEventChannelSO _setActiveInputsBoolChannel;
    [SerializeField] private BoolEventChannelSO _setActiveBirdAnimatorBoolChannel;
    [SerializeField] private BoolEventChannelSO _setRbodySimulatedBoolChannel;
    [SerializeField] private BoolEventChannelSO _setCanSpawnBoolChannel;
    [SerializeField] private BoolEventChannelSO _setCanDeactivatePoolableBoolChannel;

    [Header("Load Channels")]
    [SerializeField] private LoadEventChannelSO _locationLoadChannel;

    [Header("Float Channels")]
    [SerializeField] private FloatEventChannelSO _setSpeedPipeFloatChannel;
    [SerializeField] private FloatEventChannelSO _setSpeedGroundFloatChannel;

    void OnEnable()
    {
        _pauseVoidChannel.OnVoidRequested += PauseGame;
        _unpauseVoidChannel.OnVoidRequested += ResetParameters;

        _collisionVoidChannel.OnVoidRequested += OnLost;
        _restartVoidChannel.OnVoidRequested += Restart;
        _endTransitionVoidChannel.OnVoidRequested += ResetInputs;

        _quitLoadChannel.OnVoidRequested += QuitGame;
    }
    void OnDisable()
    {
        _pauseVoidChannel.OnVoidRequested -= PauseGame;
        _unpauseVoidChannel.OnVoidRequested -= ResetParameters;

        _collisionVoidChannel.OnVoidRequested -= OnLost;
        _restartVoidChannel.OnVoidRequested -= Restart;
        _endTransitionVoidChannel.OnVoidRequested -= ResetInputs;

        _quitLoadChannel.OnVoidRequested -= QuitGame;
    }
    
    void PauseGame()
    {
        _setActiveBirdAnimatorBoolChannel.RaiseEvent(false);
        _setRbodySimulatedBoolChannel.RaiseEvent(false);
        _setSpeedPipeFloatChannel.RaiseEvent(0f);
        _setSpeedGroundFloatChannel.RaiseEvent(0f);
        _setCanSpawnBoolChannel.RaiseEvent(false);
        _setCanDeactivatePoolableBoolChannel.RaiseEvent(false);
    }

    void ResetParameters()
    {
        _setActiveBirdAnimatorBoolChannel.RaiseEvent(true);
        _setRbodySimulatedBoolChannel.RaiseEvent(true);
        _setSpeedPipeFloatChannel.RaiseEvent(_balancingContainer.pipeSpeed);
        _setSpeedGroundFloatChannel.RaiseEvent(_balancingContainer.groundSpeed);
        _setCanSpawnBoolChannel.RaiseEvent(true);
        _setCanDeactivatePoolableBoolChannel.RaiseEvent(true);
    }

    void OnLost()
    {
        _setActiveBirdAnimatorBoolChannel.RaiseEvent(false);
        _setRbodySimulatedBoolChannel.RaiseEvent(false);
        _setSpeedPipeFloatChannel.RaiseEvent(0f);
        _setSpeedGroundFloatChannel.RaiseEvent(0f);
        _setCanSpawnBoolChannel.RaiseEvent(false);
        _setCanDeactivatePoolableBoolChannel.RaiseEvent(false);
        _setActiveInputsBoolChannel.OnBoolRequested(false);
    }

    void Restart()
    {
        _locationLoadChannel.RaiseEvent(_sceneAfterLost);        
    }

    void ResetInputs()
    {
        _setActiveInputsBoolChannel.OnBoolRequested(true);
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
