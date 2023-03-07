using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHandler : MonoBehaviour
{
    [Header("Others")]
    [SerializeField] private Animator _animator;
    [SerializeField] private BalancingContainerSO _balancingContainer;

    [Header("Channel")]
    [SerializeField] private FloatEventChannelSO _setSpeedGroundFloatChannel;

    void OnEnable()
    {
        _setSpeedGroundFloatChannel.OnFloatRequested += SetSpeedAnimationClip;
    }

    void OnDisable()
    {
        _setSpeedGroundFloatChannel.OnFloatRequested -= SetSpeedAnimationClip;        
    }

    void Start()
    {
        SetSpeedAnimationClip(_balancingContainer.groundSpeed);
    }

    void SetSpeedAnimationClip(float speed)
    {
        _animator.speed = speed;
    }
}
