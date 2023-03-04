using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [Header("Pause")]
    [SerializeField] private VoidEventChannelSO _pauseVoidChannel;
    [SerializeField] private VoidEventChannelSO _unpauseVoidChannel;

    [Header("Lost")]
    [SerializeField] private GameObject _lostPanel;
    [SerializeField] private GameSceneSO _sceneAfterLost;

    [Header("Score")]
    [SerializeField] private TMP_Text _pointsText;
    [SerializeField] private TMP_Text _finalPointsText;
    [SerializeField] private int _points;

    [Header("Void Channels")]
    [SerializeField] private VoidEventChannelSO _collisionVoidChannel;
    [SerializeField] private VoidEventChannelSO _restartVoidChannel;
    [SerializeField] private VoidEventChannelSO _resetTimeScaleVoidChannel;
    [SerializeField] private VoidEventChannelSO _quitLoadChannel;

    [Header("Bool Channels")]
    [SerializeField] private BoolEventChannelSO _setActiveInputsBoolChannel;
    [SerializeField] private BoolEventChannelSO _setActiveBirdAnimatorBoolChannel;
    [SerializeField] private BoolEventChannelSO _setRbodySimulatedBoolChannel;
    [SerializeField] private BoolEventChannelSO _setCanSpawnBoolChannel;
    [SerializeField] private BoolEventChannelSO _setCanDeactivatePoolableBoolChannel;

    [Header("Load Channels")]
    [SerializeField] private LoadEventChannelSO _locationLoadChannel;

    [Header("Int Channels")]
    [SerializeField] private IntEventChannelSO _scoreIntChannel;

    [Header("Float Channels")]
    [SerializeField] private FloatEventChannelSO _setSpeedPipeFloatChannel;
    [SerializeField] private FloatEventChannelSO _setSpeedGroundFloatChannel;

    [Header("Event")]
    [SerializeField] private UnityEvent _OnScored;

    void OnEnable()
    {
        _pauseVoidChannel.OnVoidRequested += PauseGame;
        _unpauseVoidChannel.OnVoidRequested += ResetParameters;

        _collisionVoidChannel.OnVoidRequested += OnLost;
        _restartVoidChannel.OnVoidRequested += Restart;
        _resetTimeScaleVoidChannel.OnVoidRequested += ResetParameters;

        _scoreIntChannel.OnIntRequested += SetScored;
        _collisionVoidChannel.OnVoidRequested += SetFinalPoints;

        _quitLoadChannel.OnVoidRequested += QuitGame;
    }
    void OnDisable()
    {
        _pauseVoidChannel.OnVoidRequested -= PauseGame;
        _unpauseVoidChannel.OnVoidRequested -= ResetParameters;

        _collisionVoidChannel.OnVoidRequested -= OnLost;
        _restartVoidChannel.OnVoidRequested -= Restart;
        _resetTimeScaleVoidChannel.OnVoidRequested -= ResetParameters;

        _scoreIntChannel.OnIntRequested -= SetScored;
        _collisionVoidChannel.OnVoidRequested -= SetFinalPoints;

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
        _setSpeedPipeFloatChannel.RaiseEvent(100f);
        _setSpeedGroundFloatChannel.RaiseEvent(1f);
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

        _lostPanel.SetActive(true);
        _setActiveInputsBoolChannel.OnBoolRequested(false);
    }

    void Restart()
    {
        _locationLoadChannel.RaiseEvent(_sceneAfterLost);
        _setActiveInputsBoolChannel.OnBoolRequested(true);
    }

    void SetScored(int value)
    {
        _points += value;
        _pointsText.text = _points.ToString();
        _OnScored?.Invoke();
    }

    void SetFinalPoints()
    {
        _finalPointsText.text = _points.ToString();
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
