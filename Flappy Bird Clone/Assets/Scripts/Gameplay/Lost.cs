using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lost : MonoBehaviour
{

    [Header("Others")]
    [SerializeField] private GameObject _lostPanel;
    [SerializeField] private GameSceneSO _sceneAfterLost;

    [Header("Channels")]
    [SerializeField] private VoidEventChannelSO _collisionVoidChannel;
    [SerializeField] private VoidEventChannelSO _restartVoidChannel;
    [SerializeField] private VoidEventChannelSO _resetTimeScaleVoidChannel;
    [SerializeField] private BoolEventChannelSO _setActiveInputsBoolChannel;
    [SerializeField] private LoadEventChannelSO _locationLoadChannel;

    void OnEnable()
    {
        _collisionVoidChannel.OnVoidRequested += OnLost;
        _restartVoidChannel.OnVoidRequested += Restart;
        _resetTimeScaleVoidChannel.OnVoidRequested += ResetTimeScale;
    }

    void OnDisable()
    {
        _collisionVoidChannel.OnVoidRequested -= OnLost;
        _restartVoidChannel.OnVoidRequested -= Restart;
        _resetTimeScaleVoidChannel.OnVoidRequested -= ResetTimeScale;
    }

    void OnLost()
    {
        Time.timeScale = 0f;
        _lostPanel.SetActive(true);
        _setActiveInputsBoolChannel.OnBoolRequested(false);
    }

    void Restart()
    {
        _locationLoadChannel.RaiseEvent(_sceneAfterLost);
        _setActiveInputsBoolChannel.OnBoolRequested(true);
        ResetTimeScale();
    }

    void ResetTimeScale()
    {
        Time.timeScale = 1f;
    }
}
