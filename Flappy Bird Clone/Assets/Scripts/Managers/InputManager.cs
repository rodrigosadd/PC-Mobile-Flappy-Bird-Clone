using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [Header("Channel")]
    [SerializeField] private VoidEventChannelSO _jumpVoidChannel;
    [SerializeField] private VoidEventChannelSO _pauseVoidChannel;
    [SerializeField] private VoidEventChannelSO _unpauseVoidChannel;
    [SerializeField] private BoolEventChannelSO _setActiveInputsBoolChannel;

    [SerializeField] private PlayerInputs _playerInputs;

    bool _isPaused = false;
    bool _alreadyStart = false;

    void Awake()
    {
        _playerInputs = new PlayerInputs();
    }

    void OnEnable()
    {
        _playerInputs.Enable();
        _playerInputs.Player.Pause.Disable();

        _playerInputs.Player.Jump.performed += ctx => OnJump();
        _playerInputs.Player.Pause.performed += ctx => OnPause();

        _setActiveInputsBoolChannel.OnBoolRequested += SetActiveInputs;
    }

    void OnDisable()
    {
        _playerInputs.Disable();

        _playerInputs.Player.Jump.performed -= ctx => OnJump();
        _playerInputs.Player.Pause.performed -= ctx => OnPause();

        _setActiveInputsBoolChannel.OnBoolRequested -= SetActiveInputs;
    }

    void OnJump()
    {
        _jumpVoidChannel.RaiseEvent();

        if (!_alreadyStart)
        {
            _playerInputs.Player.Pause.Enable();
            _alreadyStart = true;
        }
    }

    void OnPause()
    {
        if (!_isPaused)
        {
            _isPaused = true;
        }
        else
        {
            _isPaused = false;
        }

        if (_isPaused)
        {
            _pauseVoidChannel.RaiseEvent();
            _playerInputs.Player.Jump.Disable();
        }
        else
        {
            _unpauseVoidChannel.RaiseEvent();
            _playerInputs.Player.Jump.Enable();
        }
    }

    void SetActiveInputs(bool value)
    {
        if (value)
        {
            _playerInputs.Enable();
        }
        else
        {
            _playerInputs.Disable();
        }
    }
}
