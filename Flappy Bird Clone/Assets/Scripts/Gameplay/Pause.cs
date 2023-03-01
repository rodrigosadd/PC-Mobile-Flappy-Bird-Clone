using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [Header("Channels")]
    [SerializeField] private VoidEventChannelSO _pauseVoidChannel;
    [SerializeField] private VoidEventChannelSO _unpauseVoidChannel;

    void OnEnable()
    {
        _pauseVoidChannel.OnVoidRequested += PauseGame;
        _unpauseVoidChannel.OnVoidRequested += UnpauseGame;
    }
    void OnDisable()
    {
        _pauseVoidChannel.OnVoidRequested -= PauseGame;
        _unpauseVoidChannel.OnVoidRequested -= UnpauseGame;
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void UnpauseGame()
    {
        Time.timeScale = 1f;
    }
}
